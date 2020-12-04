using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class cadastro_empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso não haja usuario logado, ocultará o menu de usuario da navbar
                template mPage = (template)Page.Master;
                mPage.FindControl("menu_usuario").Visible = false;
                mPage.FindControl("botao_painel").Visible = false;
            }
            else
            {
                // caso um usuario esteja logado, oculta o botão login da navbar
                // oculta botoes da navbar
                template mPage = (template)Page.Master;
                mPage.FindControl("botao_login").Visible = false;

                // preenche o nome do usuario logado no dropdown
                Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                menu_nome_logado.Text = Session["user_nome"].ToString();
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
            // Expressão Regular para tratamento do DDD e Celular
            Regex rgxDDD = new Regex(@"[1-9]{1}[1-9]{1}");
            Regex rgxTelefone = new Regex(@"(\d){4}-?(\d){4}");

            bool exitval;
            int errorsCount = 0;
            string msgText = "";

            /* Cada validação abaixo somará 1 (um) à variável 'errorsCount' e adicionará um texto de erro à variável 'msgText';
             * Ao final enviará a mensagem completa com todos os problemas a serem resolvidos;
             * A variável booleana 'exitval' retornará se a validação obteve êxito.
             */

            if (inputNome.Value.Length > 100)
            {
                ValidacaoBootstrap(inputNome.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Nome</mark> não pode conter mais de 100 caracteres, você inseriu {inputNome.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            if (inputProprietario.Value.Length > 200)
            {
                ValidacaoBootstrap(inputProprietario.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Nome do Proprietário</mark> não pode conter mais de 200 caracteres, você inseriu {inputProprietario.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            if (inputEmail.Value.Length > 70)
            {
                ValidacaoBootstrap(inputEmail.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Email</mark> não pode conter mais de 70 caracteres, você inseriu {inputEmail.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            string cnpj = inputCNPJ.Value.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (!VerifyNumericValue(cnpj) || cnpj.Length > 14)
            {
                ValidacaoBootstrap(inputCNPJ.ID, "false");
                msgText += "<p>&#149; Insira um <mark>CNPJ</mark> válido.</p>";
                errorsCount += 1;
            }

            if (!rgxDDD.IsMatch(inputDDD.Value))
            {
                ValidacaoBootstrap(inputDDD.ID, "false");
                msgText += "<p>&#149; Por favor, insira um <mark>DDD</mark> válido.</p>";
                errorsCount += 1;
            }

            string tel = inputTelefone.Value.Trim().Replace("-", "");

            if (!(bool)VerifyNumericValue(tel) || tel.Length > 8 || !rgxTelefone.IsMatch(tel))
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

            string senha = inputSenha.Value;
            string confirmarSenha = inputConfSenha.Value;

            if (!senha.Equals(confirmarSenha))
            {
                ValidacaoBootstrap(inputSenha.ID, "false");
                ValidacaoBootstrap(inputConfSenha.ID, "false");
                msgText += "<p>&#149; As senhas não conferem! Por favor, insira a mesma senha nos campos <mark>Senha</mark> e <mark>Confirmar Senha</mark>";
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
            // captura os dados dos campos
            string nome = inputNome.Value.Trim();
            string proprietario = inputProprietario.Value.Trim();
            string ddd = inputDDD.Value.Trim();
            string telefone = inputTelefone.Value.Trim().Replace("-", "");
            string ramal = inputRamal.Value.Trim();
            string cnpj = inputCNPJ.Value.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            string email = inputEmail.Value.Trim();
            string senha = inputSenha.Value;
            // cria hash da senha
            string hashSenha = CryptoHash.Encriptar(cnpj + senha);

            // recupera os dados da session
            string cep = Session["vcCEP"].ToString();
            string logradouro = Session["vcLogradouro"].ToString();
            string bairro = Session["vcBairro"].ToString();
            string cidade = Session["vcCidade"].ToString();
            string uf = Session["vcUF"].ToString();
            string numero = inputNumero.Value.Trim();
            string complemento = inputComplemento.Value.Trim();

            Conexao c = new Conexao();

            string comando_sql = "INSERT INTO tbl_empresa " +
            "(id_cnpj_empresa, nome_empresa, nome_proprietario_empresa, ddd_empresa, tel_empresa, " +
            "ramal_tel_empresa, email_empresa, logradouro_empresa_sede, numero_logradouro_empresa_sede, " +
            "complemento_empresa_sede, cep_empresa_sede, bairro_empresa_sede, cidade_empresa_sede, estado_empresa_sede, " +
            "senha_empresa) " +
            "VALUES (@cnpj, @nome, @prop, @ddd, @tel, @ramal, @email, @logra, @numero, @compl, @cep, @bairro, @cidade, @uf, @senha)";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@cnpj", SqlDbType.VarChar) {Value = cnpj},
                new SqlParameter("@nome", SqlDbType.VarChar) {Value = nome},
                new SqlParameter("@prop", SqlDbType.VarChar) {Value = proprietario},
                new SqlParameter("@ddd", SqlDbType.SmallInt) {Value = ddd},
                new SqlParameter("@tel", SqlDbType.Int) {Value = telefone},
                new SqlParameter("@ramal", SqlDbType.VarChar) {Value = ramal},
                new SqlParameter("@email", SqlDbType.VarChar) {Value = email},

                new SqlParameter("@logra", SqlDbType.VarChar) {Value = logradouro},
                new SqlParameter("@numero", SqlDbType.VarChar) {Value = numero},
                new SqlParameter("@compl", SqlDbType.VarChar) {Value = complemento},
                new SqlParameter("@cep", SqlDbType.VarChar) {Value = cep},
                new SqlParameter("@bairro", SqlDbType.VarChar) {Value = bairro},
                new SqlParameter("@cidade", SqlDbType.VarChar) {Value = cidade},
                new SqlParameter("@uf", SqlDbType.VarChar) {Value = uf},
                new SqlParameter("@senha", SqlDbType.VarChar) {Value = hashSenha}
            };

            bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

            if (cadastrado)
            {
                inputNome.Value = "";
                inputProprietario.Value = "";
                inputDDD.Value = "";
                inputTelefone.Value = "";
                inputRamal.Value = "";
                inputCNPJ.Value = "";
                inputEmail.Value = "";
                inputCEP.Text = "";
                inputLogradouro.Value = "";
                inputNumero.Value = "";
                inputComplemento.Value = "";
                inputBairro.Value = "";
                inputCidade.Value = "";
                inputUF.Value = "";

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