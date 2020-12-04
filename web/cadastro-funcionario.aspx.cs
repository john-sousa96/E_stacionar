using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class cadastro_funcionario : System.Web.UI.Page
    {
        private DataTable dt;
        private Conexao c = new Conexao();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=cadastro-funcionario.aspx", false);
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
                        Fill_Estacionamento();
                    }
                }
            }
        }

        private void Fill_Estacionamento()
        {
            string cnpj = Session["cpfcnpj"].ToString();

            string comando_sql = "SELECT id_estacionamento, logradouro_est, numero_est, bairro_est " +
                "FROM tbl_estacionamento " +
                "WHERE tbl_empresa_id_cnpj_empresa=@empresa " +
                "ORDER BY logradouro_est ASC";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@empresa", SqlDbType.VarChar) {Value = cnpj},
            };

            try
            {
                dt = c.ExecutarSQL(comando_sql, paramsList);

                int qtdEst = dt.Rows.Count;

                // caso a lista de estacionamento esteja vazia
                if (qtdEst == 0)
                {
                    // altera o conteudo da lista e o title do dropdown
                    inputEstacionamento.Items.Insert(0, new ListItem("Sua empresa não possui estacionamentos", "0"));
                    inputEstacionamento.ToolTip = "Sua empresa não possui nenhum estacionamento ainda.";

                    // bloqueia os campos para preenchimento
                    inputStatus.Disabled = true;
                    inputNome.Disabled = true;
                    inputCPF.Disabled = true;
                    inputCargo.Disabled = true;
                    inputSenha.Disabled = true;
                    inputConfSenha.Disabled = true;
                    btnCadastrar.Enabled = false;
                    
                    // exibe um alerta com link para a pagina de cadastro de estacionamentos
                    string msgText = "Você precisa cadastrar um estacionamento antes de cadastrar um funcionário." +
                        "<hr><a href='./cadastro-estacionamento.aspx' class='alert-link'>Clique aqui</a> para cadastrar um estacionamento.";

                    string jsFunction = $"AlertarCamposInvalidos(\"{msgText.Trim()}\");";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCamposInvalidos", jsFunction, true);
                }
                else
                {
                    // popula a lista com o endereço concatenado de cada estacionamento que a empresa possui
                    inputEstacionamento.Items.Insert(0, new ListItem("Escolher...", "0"));

                    for (int i = 0; i < qtdEst; i++)
                    {
                        long id = Int64.Parse(dt.Rows[i]["id_estacionamento"].ToString());
                        string logradouro = dt.Rows[i]["logradouro_est"].ToString();
                        string numero = dt.Rows[i]["numero_est"].ToString();
                        string bairro = dt.Rows[i]["bairro_est"].ToString();

                        string item = $"{logradouro}, {numero} - {bairro}";

                        inputEstacionamento.Items.Insert(i + 1, new ListItem(item, id.ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                // caso ocorra algum erro no SQL, printa a mensagem de erro e manda um aviso genérico ao usuario

                System.Diagnostics.Debug.WriteLine($"Erro ao preencher a lista de estacionamentos: {e}");

                string msgText = "Ocorreu um erro ao carregar a página. Por favor, recarregue a página e tente novamente." +
                    "<hr>Caso o erro persista, entre em contato conosco.";

                string jsFunction = $"AlertarCamposInvalidos(\"{msgText.Trim()}\");";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCamposInvalidos", jsFunction, true);
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
            bool exitval;
            int errorsCount = 0;
            string msgText = "";

            /* Cada validação abaixo somará 1 (um) à variável 'errorsCount' e adicionará um texto de erro à variável 'msgText';
             * Ao final enviará a mensagem completa com todos os problemas a serem resolvidos;
             * A variável booleana 'exitval' retornará se a validação obteve êxito.
             */

            if (inputEstacionamento.SelectedItem.Text.Contains("não possui"))
            {
                // no cenario da empresa nao possuir um estacionamento, será impedida de cadastrar um funcionario
                // ela verá uma mensagem gerada pelo metodo Fill_Estacionamento e todos os campos estarão desativados.
                // esse if existe apenas para caso o usuário reative o botao Cadastrar diretamente no html da página.

                ValidacaoBootstrap(inputEstacionamento.ID, "false");
                // exibe um alerta com link para a pagina de cadastro de estacionamentos
                msgText = "Você precisa cadastrar um estacionamento antes de cadastrar um funcionário." +
                        "<hr><a href='./cadastro-estacionamento.aspx' class='alert-link'>Clique aqui</a> para cadastrar um estacionamento.";
                errorsCount += 1;
            }
            else
            {
                if (inputEstacionamento.SelectedItem.Text.Equals("Escolher...") || inputEstacionamento.SelectedItem.Text.Equals("") || inputEstacionamento.Text.Equals("0"))
                {
                    ValidacaoBootstrap(inputEstacionamento.ID, "false");
                    msgText += "<p>&#149; Por favor, selecione um <mark>Estacionamento</mark> na lista.</p>";
                    errorsCount += 1;
                }

                if (inputNome.Value.Length > 200)
                {
                    ValidacaoBootstrap(inputNome.ID, "false");
                    msgText += $"<p>&#149; O campo <mark>Nome</mark> não pode conter mais de 200 caracteres, você inseriu {inputNome.Value.Length} caracteres.</p>";
                    errorsCount += 1;
                }

                string cpf = inputCPF.Value.Trim().Replace(".", "").Replace("-", "");

                if (!VerifyNumericValue(cpf) || cpf.Length > 11)
                {
                    ValidacaoBootstrap(inputCPF.ID, "false");
                    msgText += "<p>&#149; Insira um <mark>CPF</mark> válido.</p>";
                    errorsCount += 1;
                }

                if (inputCargo.Value.Length > 20)
                {
                    ValidacaoBootstrap(inputCargo.ID, "false");
                    msgText += $"<p>&#149; O campo <mark>Cargo</mark> não pode conter mais de 20 caracteres, você inseriu {inputCargo.Value.Length} caracteres.</p>";
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
            int status = Int16.Parse(inputStatus.Value);
            long idEstacionamento = Int64.Parse(inputEstacionamento.SelectedValue);
            string nome = inputNome.Value;
            string cpf = inputCPF.Value.Trim().Replace(".", "").Replace("-", "");
            string cargo = inputCargo.Value;
            string senha = inputSenha.Value;
            // cria hash da senha
            string hashSenha = CryptoHash.Encriptar(cpf + senha);

            string comando_sql = "INSERT INTO tbl_funcionario_est " +
            "(tbl_estacionamento_id_estacionamento, nome_completo_func, CPF_func, cargo_func, senha_func, status_func) " +
            "VALUES (@id_est, @nome, @cpf, @cargo, @senha, @status)";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@id_est", SqlDbType.BigInt) {Value = idEstacionamento},
                new SqlParameter("@nome", SqlDbType.VarChar) {Value = nome},
                new SqlParameter("@cpf", SqlDbType.VarChar) {Value = cpf},
                new SqlParameter("@cargo", SqlDbType.VarChar) {Value = cargo},
                new SqlParameter("@senha", SqlDbType.VarChar) {Value = hashSenha},
                new SqlParameter("@status", SqlDbType.Bit) {Value = status}
            };

            bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

            if (cadastrado)
            {
                inputStatus.SelectedIndex = 0;
                inputEstacionamento.SelectedValue = "0";
                inputNome.Value = "";
                inputCPF.Value = "";
                inputCargo.Value = "";

                // mostra o alerta de sucesso do boostrap via js
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCadastroSucesso", "AlertaCadastroBemSucedido();", true);
            }
            else
            {
                // mostra uma mensagem de erro ao usuario caso não seja possível cadastrar
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