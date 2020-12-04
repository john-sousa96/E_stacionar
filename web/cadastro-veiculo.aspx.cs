using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class cadastro_veiculo : System.Web.UI.Page
    {
        private DataTable dt;
        private Conexao c = new Conexao();

        private string placa;

        public string userNome { get; private set; }
        public string MsgSucesso { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=cadastro-veiculo.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                // caso um usuario esteja logado
                int permissao = Convert.ToInt32(Session["user_perm"].ToString());

                // redireciona para a pagina 403 se o usuario logado nao for 'usuario'(4)
                if (permissao != 4)
                {
                    Response.StatusCode = 403;
                }

                // variavel será usada pelo codigo javascript
                userNome = Session["user_nome"].ToString();

                if (!IsPostBack)
                {
                    Fill_Estado();

                    // oculta o botão login da navbar
                    template mPage = (template)Page.Master;
                    mPage.FindControl("botao_login").Visible = false;

                    // preenche o nome do usuario logado no dropdown
                    Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                    menu_nome_logado.Text = Session["user_nome"].ToString();
                }
            }
        }

        private void Fill_Estado()
        {
            // Popula o dropdown UF com as siglas dos estados
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("estados.xml"));

            inputUF.DataValueField = "ID";
            inputUF.DataTextField = "SIGLA";
            inputUF.DataSource = ds;
            inputUF.DataBind();
            inputUF.Items.Insert(0, new ListItem("Escolher...", "0"));
        }

        protected void inputUF_Changed(object sender, EventArgs e)
        {
            // a cada alteração do dropdown UF/Estado a lista de cidades é atualizada
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("cidades.xml"));

            // filtra a lista de cidades pelo ID do estado selecionado
            string filtro = $"IDESTADO = {inputUF.SelectedValue}";
            DataView dsFiltrado = ds.Tables[0].DefaultView;
            dsFiltrado.RowFilter = filtro;
            var newDS = new DataSet();
            newDS.Tables.Add(dsFiltrado.ToTable());
            inputCidade.DataValueField = "ID";
            inputCidade.DataTextField = "NOME";
            inputCidade.DataSource = newDS;
            inputCidade.DataBind();
            inputCidade.Items.Insert(0, new ListItem("Escolher...", "0"));
        }

        protected void inputPlaca_Changed(object sender, EventArgs e)
        {
            placa = inputPlaca.Text.ToUpper();
            lblPlaca.Text = placa;

            if (UsuarioPossuiVeiculo(placa))
            {
                ShowMessageSuccess("Você já possui este veículo! Confira no menu <a href='./gerenciar-veiculos.aspx' class='alert-link'>Veículos</a>");
            }
            else
            {
                // caso a placa inserida pelo usuario já exista no sistema,
                // exibirá um modal solicitando confirmação do token
                if (VeiculoExiste(placa))
                {
                    ShowHideModalScript("ModalConfirmarToken", true);
                }
                else
                {
                    inputMarca.Focus();
                }
            }
        }

        private bool UsuarioPossuiVeiculo(string placa)
        {
            // Ao clicar no botao 'Confirmar' do modal de confirmação do token
            string usuario = Session["cpfcnpj"].ToString();

            // seleciona o veículo 
            string comando_sql = "SELECT * FROM tbl_user_veiculo " +
                "WHERE id_CPF_usuario=@usuario " +
                "AND id_placa_veiculo=@placa";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", SqlDbType.VarChar) {Value = usuario},
                new SqlParameter("@placa", SqlDbType.VarChar) {Value = placa},
            };

            dt = c.ExecutarSQL(comando_sql, paramsList);

            int qtd = dt.Rows.Count;

            if (qtd == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnConfirmarToken_Click(object sender, EventArgs e)
        {
            string idToken = txtIDToken.Value;

            if (!(bool)VerifyNumericValue(idToken) || idToken.Length > 10 || idToken.Length == 0)
            {
                ShowMessageErrorScript("Por favor, insira um token válido. <a href='#' class='alert-link' data-toggle='modal' data-target='#ModalConfirmarToken'>Tente novamente!</a>");
            }
            else
            {
                // Ao clicar no botao 'Confirmar' do modal de confirmação do token
                string placa = inputPlaca.Text;
                string usuario = Session["cpfcnpj"].ToString();

                // seleciona o veículo 
                string comando_sql = "SELECT * FROM tbl_veiculos " +
                    "WHERE id_placa_veiculo=@placa " +
                    "AND tbl_token_id_token=@token";

                List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@placa", SqlDbType.VarChar) {Value = placa},
                new SqlParameter("@token", SqlDbType.BigInt) {Value = idToken},
            };

                dt = c.ExecutarSQL(comando_sql, paramsList);

                int qtd = dt.Rows.Count;

                if (qtd == 0)
                {
                    ShowMessageErrorScript("O token inserido não confere. <a href='#' class='alert-link' data-toggle='modal' data-target='#ModalConfirmarToken'>Tente novamente!</a>");
                }
                else
                {
                    bool sucesso = AssociarVeiculoUsuario(usuario, placa);

                    if (sucesso)
                    {
                        ShowMessageSuccess("Veículo confirmado com sucesso! Agora ele já está disponível no menu <a href='./gerenciar-veiculos.aspx' class='alert-link'>Veículos</a>");
                    }
                    else
                    {
                        ShowMessageErrorScript("Ocorreu um erro ao validar o token. Entre em contato com o suporte!");
                    }
                }
            }

            txtIDToken.Value = "";
            ShowHideModalScript("ModalConfirmarToken", false);
        }

        private bool AssociarVeiculoUsuario(string usuario, string placa)
        {
            string comando_sql = "INSERT INTO tbl_user_veiculo " +
                "(id_CPF_usuario, id_placa_veiculo) " +
                "VALUES (@usuario, @placa)";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", SqlDbType.VarChar) {Value = usuario},
                new SqlParameter("@placa", SqlDbType.VarChar) {Value = placa},
            };

            bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

            return cadastrado;
        }

        private int ObterTokenLivre()
        {
            string comando_sql = "SELECT id_token " +
                "FROM tbl_token " +
                "WHERE id_token " +
                "NOT IN (SELECT tbl_token_id_token " +
                "FROM tbl_veiculos)";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            dt = c.ExecutarSQL(comando_sql, paramsList);

            int qtd = dt.Rows.Count;
            int idToken;

            if (qtd == 0)
            {
                idToken = 0;
            }
            else
            {
                // retorna o primeiro resultado da lista
                idToken = Int16.Parse(dt.Rows[0]["id_token"].ToString());
            }

            return idToken;
        }

        private bool CadastraNovoToken()
        {
            string comando_sql = "INSERT INTO tbl_token (status_token) VALUES (1)";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

            return cadastrado;
        }

        private bool VeiculoExiste(string placa)
        {
            // lista o veiculo correspondente a placa inserida pelo usuario na pagina
            string comando_sql = "SELECT * FROM tbl_veiculos " +
                "WHERE id_placa_veiculo=@placa";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@placa", SqlDbType.VarChar) {Value = placa}
            };

            dt = c.ExecutarSQL(comando_sql, paramsList);

            // retorna a quantidade
            int qtd = dt.Rows.Count;

            if (qtd == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            placa = inputPlaca.Text.ToUpper();

            if (UsuarioPossuiVeiculo(placa))
            {
                // mostra o alerta de sucesso do boostrap via js
                MsgSucesso = "Você já possui este veículo! Confira no menu <a href='./gerenciar-veiculos.aspx' class='alert-link'>Veículos</a>";
            }
            else
            {
                // se todos os dados inseridos forem válidos, chamará um método para armazenar no BD
                if (ValidarDadosInseridos())
                {
                    SalvarDadosBD();
                }
            }
        }

        public bool ValidarDadosInseridos()
        {
            // Expressão Regular para tratamento da Placa do veículo
            // Tanto a placa do Mercosul quanto a anterior são suportadas
            Regex rgxPlaca = new Regex(@"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");

            bool exitval;
            int errorsCount = 0;
            string msgText = "";

            /* Cada validação abaixo somará 1 (um) à variável 'errorsCount' e adicionará um texto de erro à variável 'msgText';
             * Ao final enviará a mensagem completa com todos os problemas a serem resolvidos;
             * A variável booleana 'exitval' retornará se a validação obteve êxito.
             */

            if (rdbPropVeiculoNao.Checked)
            {
                if (inputProprietario.Value.Length > 150 || inputProprietario.Value.Equals(""))
                {
                    ValidacaoBootstrap(inputProprietario.ID, "false");
                    msgText += $"<p>&#149; O campo <mark>Nome do Proprietário</mark> não pode estar vazio ou conter mais de 150 caracteres, você inseriu {inputProprietario.Value.Length} caracteres.</p>";
                    errorsCount += 1;
                }
            }

            placa = inputPlaca.Text.ToUpper();

            if (!rgxPlaca.IsMatch(placa) || placa.Length > 7)
            {
                ValidacaoBootstrap(inputPlaca.ID, "false");
                msgText += "<p>&#149; Por favor, insira uma <mark>Placa</mark> válida.</p>";
                errorsCount += 1;
            }

            if (inputUF.SelectedItem.Text.Equals("Escolher...") || inputUF.SelectedItem.Text.Equals("") || inputUF.Text.Equals("0"))
            {
                ValidacaoBootstrap(inputUF.ID, "false");
                msgText += "<p>&#149; Por favor, selecione uma <mark>UF</mark> na lista.</p>";
                errorsCount += 1;
            }

            if (inputCidade.SelectedItem.Text.Equals("Escolher...") || inputCidade.SelectedItem.Text.Equals("") || inputCidade.Text.Equals("0"))
            {
                ValidacaoBootstrap(inputCidade.ID, "false");
                msgText += "<p>&#149; Por favor, selecione uma <mark>Cidade</mark> na lista. Selecione uma <mark>UF</mark> primeiro.</p>";
                errorsCount += 1;
            }

            if (inputMarca.Value.Length > 30 || inputMarca.Value.Length == 0)
            {
                ValidacaoBootstrap(inputMarca.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Marca</mark> não pode conter mais de 30 caracteres, você inseriu {inputMarca.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            if (inputModelo.Value.Length > 20 || inputModelo.Value.Length == 0)
            {
                ValidacaoBootstrap(inputModelo.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Modelo</mark> não pode conter mais de 20 caracteres, você inseriu {inputModelo.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            if (inputCor.Value.Length > 20 || inputCor.Value.Length == 0)
            {
                ValidacaoBootstrap(inputCor.ID, "false");
                msgText += $"<p>&#149; O campo <mark>Cor</mark> não pode conter mais de 20 caracteres, você inseriu {inputCor.Value.Length} caracteres.</p>";
                errorsCount += 1;
            }

            // se a soma de erros for maior que zero enviará a mensagem ao usuario atraves da div alert do Bootstrap via js
            if (errorsCount > 0)
            {
                ShowMessageErrorScript(msgText);
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
            try
            {
                string usuario = Session["cpfcnpj"].ToString();
                string proprietario;

                // captura os dados dos campos
                if (rdbPropVeiculoSim.Checked)
                {
                    // usa o nome do usuario logado como proprietario do veiculo
                    proprietario = Session["user_nome"].ToString();
                }
                else
                {
                    // usa o nome inserido no campo Nome do Proprietario da pagina
                    proprietario = inputProprietario.Value;
                }

                string marca = inputMarca.Value;
                string modelo = inputModelo.Value;
                string cor = inputCor.Value;
                string uf = inputUF.SelectedItem.Text;
                string cidade = inputCidade.SelectedItem.Text;
                bool seguro = checkSeguro.Checked;

                // obtém o id de um token livre
                int idToken = ObterTokenLivre();

                if (idToken == 0)
                {
                    // cadastra um novo token caso não exista tokens sem uso
                    CadastraNovoToken();
                    idToken = ObterTokenLivre();
                }

                string comando_sql = "INSERT INTO tbl_veiculos " +
                "(id_placa_veiculo, tbl_token_id_token, nome_prop_veiculo, cidade_veiculo, estado_veiculo, marca_veiculo, modelo_veiculo, cor_veiculo, seguro_veiculo) " +
                "VALUES (@placa, @idToken, @prop, @cidade, @uf, @marca, @modelo, @cor, @seguro)";

                List<SqlParameter> paramsList = new List<SqlParameter>()
                {
                    new SqlParameter("@placa", SqlDbType.VarChar) {Value = placa}, // private string acima do metodo Page_Load
                    new SqlParameter("@idToken", SqlDbType.Int) {Value = idToken},
                    new SqlParameter("@prop", SqlDbType.VarChar) {Value = proprietario},
                    new SqlParameter("@cidade", SqlDbType.VarChar) {Value = cidade},
                    new SqlParameter("@uf", SqlDbType.VarChar) {Value = uf},
                    new SqlParameter("@marca", SqlDbType.VarChar) {Value = marca},
                    new SqlParameter("@modelo", SqlDbType.VarChar) {Value = modelo},
                    new SqlParameter("@cor", SqlDbType.VarChar) {Value = cor},
                    new SqlParameter("@seguro", SqlDbType.Bit) {Value = seguro}
                };

                bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

                if (cadastrado)
                {
                    bool associado = AssociarVeiculoUsuario(usuario, placa);

                    if (associado)
                    {
                        rdbPropVeiculoNao.Checked = false;
                        rdbPropVeiculoSim.Checked = true;
                        inputPlaca.Text = "";
                        inputMarca.Value = "";
                        inputModelo.Value = "";
                        inputCor.Value = "";
                        inputUF.SelectedIndex = 0;
                        inputCidade.SelectedIndex = 0;
                        checkSeguro.Checked = false;

                        // mostra o alerta de sucesso do boostrap via js
                        MsgSucesso = "Veículo cadastrado com sucesso!";
                    }
                }
            }
            catch (Exception e)
            {
                // caso ocorra algum erro no SQL, printa a mensagem de erro e manda um aviso genérico ao usuario

                System.Diagnostics.Debug.WriteLine($"Erro ao cadastrar veiculo: {e}");

                string msgText = "Não foi possível realizar o cadastro. Por favor, tente novamente." +
                    "<hr>Caso o erro persista, entre em contato conosco.";

                ShowMessageErrorScript(msgText);
            }
        }

        private void ShowHideModalScript(string modal, bool status)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#" + modal + "').modal('" + (status ? "show" : "hide") + "');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "startScript", sb.ToString(), false);
        }

        private void ShowMessageSuccess(string message)
        {
            // mostra o alerta de sucesso do boostrap via js
            string jsFunction = $"AlertarSucesso(\"{message}\");";
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertarSucesso", jsFunction, true);
        }

        private void ShowMessageErrorScript(String message)
        {
            // mostra o alerta de erro do boostrap via js
            string jsFunction = $"AlertarErro(\"{message}\");";
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertarErro", jsFunction, true);
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