using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class cadastro_estacionamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=cadastro-estacionamento.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                // caso um usuario esteja logado
                int permissao = Convert.ToInt32(Session["user_perm"].ToString());

                // redireciona para a pagina 403 se o usuario logado nao for 'empresa'(2)
                if (permissao != 2)
                {
                    Response.StatusCode = 403;
                }
                else
                {
                    // oculta botoes da navbar
                    template mPage = (template)Page.Master;
                    mPage.FindControl("botao_login").Visible = false;

                    // preenche o nome do usuario logado no dropdown
                    Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                    menu_nome_logado.Text = Session["user_nome"].ToString();

                    if (!IsPostBack)
                    {
                        Fill_Regiao();
                    }
                }
            }
        }

        protected void inputCEP_Changed(object sender, EventArgs e)
        {
            // executado toda vez que o usuario preenche o CEP e sai do campo

            string CEP = inputCEP.Text.Replace("-", "");

            if (!(bool)VerifyNumericValue(CEP) || CEP.Length != 8)
            {
                // insere validação do bootstrap abaixo do campo de texto
                ValidacaoBootstrap(inputCEP.ID, "false");
                System.Diagnostics.Debug.WriteLine($"CEP Inserido : {inputCEP.Text}");
            }
            else
            {
                string urlViaCEP = "https://viacep.com.br/ws/" + CEP + "/xml/";
                string xmlResponse;

                // abre conexão com a API ViaCEP
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/xml"));

                    HttpResponseMessage response;

                    response = client.GetAsync(urlViaCEP).Result;
                    xmlResponse = response.Content.ReadAsStringAsync().Result;
                }

                // converte o conteúdo da resposta HTML para XML
                XmlTextReader xmlData = new XmlTextReader(new System.IO.StringReader(xmlResponse));

                DataSet ds = new DataSet();
                ds.ReadXml(xmlData);

                if (ds.Tables[0].Columns.Contains("erro"))
                {
                    // se o CEP não existir
                    // insere validação do bootstrap abaixo do campo de texto
                    ValidacaoBootstrap(inputCEP.ID, "false");
                    System.Diagnostics.Debug.WriteLine("CEP não existe");
                }
                else
                {
                    // se o CEP existir,
                    // insere validação do bootstrap dentro do campo de texto
                    ValidacaoBootstrap(inputCEP.ID, "true");

                    DataRowView tbl = ds.Tables[0].DefaultView[0];

                    // armazena o retorno da API
                    Session["vcCEP"] = tbl.Row["cep"].ToString().Replace("-", "");
                    Session["vcLogradouro"] = tbl.Row["logradouro"].ToString();
                    Session["vcBairro"] = tbl.Row["bairro"].ToString();
                    Session["vcCidade"] = tbl.Row["localidade"].ToString();
                    Session["vcUF"] = tbl.Row["uf"].ToString();

                    // preenche os campos do endereço com os dados da API
                    inputLogradouro.Value = Session["vcLogradouro"].ToString();
                    inputBairro.Value = Session["vcBairro"].ToString();
                    inputCidade.Value = Session["vcCidade"].ToString();
                    inputUF.Value = Session["vcUF"].ToString();

                    inputNumero.Focus();
                }
            }
        }

        private void Fill_Regiao()
        {
            List<ListItem> regioes = new List<ListItem>();
            regioes.Add(new ListItem("Norte","1"));
            regioes.Add(new ListItem("Sul","2"));
            regioes.Add(new ListItem("Centro","3"));
            regioes.Add(new ListItem("Leste","4"));
            regioes.Add(new ListItem("Oeste","5"));

            inputRegiao.DataValueField = "Value";
            inputRegiao.DataTextField = "Text";
            inputRegiao.DataSource = regioes;
            inputRegiao.DataBind();
            inputRegiao.Items.Insert(0, new ListItem("Escolher...", "0"));
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            // se todos os dados inseridos forem válidos, chamará um método para armazenar no BD
            if (ValidarDadosInseridos())
            {
                SalvarDadosBD();
            }
        }

        public bool ValidarDadosInseridos()
        {
            // Expressão Regular para tratamento do DDD e Telefone
            Regex rgxDDD = new Regex(@"[1-9]{1}[1-9]{1}");
            Regex rgxTelCel = new Regex(@"(\d){4,5}-?(\d){4}");

            bool exitval;
            int errorsCount = 0;
            string msgText = "";

            /* Cada validação abaixo somará 1 (um) à variável 'errorsCount' e adicionará um texto de erro à variável 'msgText';
             * Ao final enviará a mensagem completa com todos os problemas a serem resolvidos;
             * A variável booleana 'exitval' retornará se a validação obteve êxito.
             */

            if (inputNumero.Value.Length > 10)
            {
                ValidacaoBootstrap(inputNumero.ID, "false");
                msgText = "<p>&#149; O campo <mark>Número</mark> não pode conter mais de 10 caracteres. Utilize o campo <mark>Complemento</mark>, se necessário.</p>";
                errorsCount += 1;
            }

            if (inputComplemento.Value.Length > 200)
            {
                ValidacaoBootstrap(inputComplemento.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Complemento</mark> não pode conter mais de 200 caracteres, você inseriu {inputComplemento.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            if (inputRegiao.SelectedItem.Text.Equals("Escolher...") || inputRegiao.SelectedItem.Text.Equals("") || inputRegiao.Text.Equals("0"))
            {
                ValidacaoBootstrap(inputRegiao.ID, "false");
                msgText += "<p>&#149; Por favor, selecione uma <mark>Região</mark> na lista.</p>";
                errorsCount += 1;
            }

            if (!rgxDDD.IsMatch(inputDDD.Value))
            {
                ValidacaoBootstrap(inputDDD.ID, "false");
                msgText += "<p>&#149; Por favor, insira um <mark>DDD</mark> válido.</p>";
                errorsCount += 1;
            }
            
            string tel = inputTelefone.Value.Replace("-", "");

            if (!VerifyNumericValue(tel) || tel.Length > 9 || !rgxTelCel.IsMatch(tel))
            {
                ValidacaoBootstrap(inputTelefone.ID, "false");
                msgText += "<p>&#149; Por favor, insira um <mark>Telefone</mark> válido sem o DDD.</p>";
                errorsCount += 1;
            }

            if (inputRamal.Value.Length > 10)
            {
                ValidacaoBootstrap(inputRamal.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Ramal</mark> não pode conter mais de 10 caracteres, você inseriu {inputRamal.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            if (inputLat.Value.Length > 30 || inputLat.Value.Equals(""))
            {
                ValidacaoBootstrap(inputLat.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Latitude</mark> não pode estar vazio ou conter mais de 30 caracteres. Clique no botão <mark>Abrir Mapa</mark> abaixo!</p>";
                errorsCount += 1;
            }

            if (inputLng.Value.Length > 30 || inputLng.Value.Equals(""))
            {
                ValidacaoBootstrap(inputLng.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Longitude</mark> não pode estar vazio ou conter mais de 30 caracteres. Clique no botão <mark>Abrir Mapa</mark> abaixo!</p>";
                errorsCount += 1;
            }

            // se a soma de erros for maior que zero enviará a mensagem ao usuario atraves da div alert do Bootstrap via js
            if (errorsCount > 0)
            {
                string jsFunction = $"AlertarCamposInvalidos(\"{msgText.Trim()}\");";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCamposInvalidos", jsFunction, true);
                exitval = false;
            }
            else
            {
                exitval = true;
            }

            return exitval;
        }
    
        public void SalvarDadosBD()
        {
            // recupera os dados da session
            string cnpj = Session["cpfcnpj"].ToString();
            string cep = Session["vcCEP"].ToString();
            string logradouro = Session["vcLogradouro"].ToString();
            string bairro = Session["vcBairro"].ToString();
            string cidade = Session["vcCidade"].ToString();
            string uf = Session["vcUF"].ToString();

            // captura os dados dos campos
            int status = Int16.Parse(inputStatus.Value);
            string numero = inputNumero.Value.Trim();
            string complemento = inputComplemento.Value.Trim();
            string regiao = inputRegiao.SelectedItem.Text;
            string ddd = inputDDD.Value.Trim();
            string telefone = inputTelefone.Value.Trim().Replace("-", "");
            string ramal = inputRamal.Value.Trim();
            string lat = inputLat.Value;
            string lng = inputLng.Value;

            Conexao c = new Conexao();

            string comando_sql = "INSERT INTO tbl_estacionamento " +
            "(tbl_empresa_id_cnpj_empresa, logradouro_est, numero_est, complemento_est, CEP_est, bairro_est, " +
            "regiao_est, cidade_est, estado_est, status_est, ddd_tel_est, tel_est, ramal_est, lat_est, lng_est) " +
            "VALUES (@cnpj, @logra, @numero, @compl, @cep, @bairro, @regiao, @cidade, @uf, @status, @ddd, @tel, @ramal, @lat, @lng)";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@cnpj", SqlDbType.VarChar) {Value = cnpj},
                new SqlParameter("@logra", SqlDbType.VarChar) {Value = logradouro},
                new SqlParameter("@numero", SqlDbType.VarChar) {Value = numero},
                new SqlParameter("@compl", SqlDbType.VarChar) {Value = complemento},
                new SqlParameter("@cep", SqlDbType.VarChar) {Value = cep},
                new SqlParameter("@bairro", SqlDbType.VarChar) {Value = bairro},
                new SqlParameter("@regiao", SqlDbType.VarChar) {Value = regiao},
                new SqlParameter("@cidade", SqlDbType.VarChar) {Value = cidade},
                new SqlParameter("@uf", SqlDbType.VarChar) {Value = uf},
                new SqlParameter("@status", SqlDbType.Bit) {Value = status},
                new SqlParameter("@ddd", SqlDbType.SmallInt) {Value = ddd},
                new SqlParameter("@tel", SqlDbType.Int) {Value = telefone},
                new SqlParameter("@ramal", SqlDbType.VarChar) {Value = ramal},
                new SqlParameter("@lat", SqlDbType.VarChar) {Value = lat},
                new SqlParameter("@lng", SqlDbType.VarChar) {Value = lng},
            };

            bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

            if (cadastrado)
            {
                inputStatus.SelectedIndex = 0;
                inputCEP.Text = "";
                inputLogradouro.Value = "";
                inputNumero.Value = "";
                inputComplemento.Value = "";
                inputBairro.Value = "";
                inputRegiao.SelectedValue = "0";
                inputCidade.Value = "";
                inputUF.Value = "";
                inputDDD.Value = "";
                inputTelefone.Value = "";
                inputRamal.Value = "";
                inputLat.Value = "";
                inputLng.Value = "";

                // mostra o alerta de sucesso do boostrap via js
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCadastroSucesso", "AlertaCadastroBemSucedido();", true);
            }
            else
            {
                // mostra uma mensagem de erro ao usuario caso não seja possível cadastrar
                // A classe Conexão printará o código do erro antes.
                string msgText = "Não foi possível realizar o cadastro. Por favor, tente novamente." +
                    "<hr>Caso o erro persista, entre em contato conosco.";

                string jsFunction = $"AlertarCamposInvalidos(\"{msgText.Trim()}\");";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCamposInvalidos", jsFunction, true);
            }
        }

        public void ValidacaoBootstrap(string element, string booleano)
        {
            element = $"BodyContent_{element}";
            // chama função javascript (main.js) para alterar a classe de validação do bootstrap
            string jsFunction = $"ValidarCampo({element},{booleano});";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidarCampo", jsFunction, true);
        }

        public bool VerifyNumericValue(string ValueToCheck)
        {
            bool rslt = long.TryParse(ValueToCheck, out long numval);

            return rslt;
        }
    }
}