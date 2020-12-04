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
    public partial class cadastro_usuario : System.Web.UI.Page
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
            Regex rgxCel = new Regex(@"(\d){5}-?(\d){4}");

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

            string cpf = inputCPF.Value.Trim().Replace(".", "").Replace("-", "");

            if (!VerifyNumericValue(cpf) || cpf.Length > 11)
            {
                ValidacaoBootstrap(inputCPF.ID, "false");
                msgText += "<p>&#149; Insira um <mark>CPF</mark> válido.</p>";
                errorsCount += 1;
            }

            if (!rgxDDD.IsMatch(inputDDD.Value))
            {
                ValidacaoBootstrap(inputDDD.ID, "false");
                msgText += "<p>&#149; Por favor, insira um <mark>DDD</mark> válido.</p>";
                errorsCount += 1;
            }

            string tel = inputCelular.Value.Trim().Replace("-", "");

            if (!(bool)VerifyNumericValue(tel) || tel.Length > 9 || !rgxCel.IsMatch(tel))
            {
                ValidacaoBootstrap(inputCelular.ID, "false");
                msgText += "<p>&#149; Por favor, insira um <mark>Celular</mark> válido sem o DDD.</p>";
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
            string cpf = inputCPF.Value.Trim().Replace(".", "").Replace("-", "");
            string ddd = inputDDD.Value.Trim();
            string celular = inputCelular.Value.Trim().Replace("-", "");
            string email = inputEmail.Value.Trim();
            string senha = inputSenha.Value;
            // cria hash da senha
            string hashSenha = CryptoHash.Encriptar(cpf + senha);

            Conexao c = new Conexao();

            string comando_sql = "INSERT INTO tbl_usuario " +
            "(id_CPF_usuario, nome_usuario, ddd_cel, cel_usuario, email_usuario, senha_usuario) " +
            "VALUES (@cpf, @nome, @ddd, @cel, @email, @senha)";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@cpf", SqlDbType.VarChar) {Value = cpf},
                new SqlParameter("@nome", SqlDbType.VarChar) {Value = nome},
                new SqlParameter("@ddd", SqlDbType.SmallInt) {Value = ddd},
                new SqlParameter("@cel", SqlDbType.Int) {Value = celular},
                new SqlParameter("@email", SqlDbType.VarChar) {Value = email},
                new SqlParameter("@senha", SqlDbType.VarChar) {Value = hashSenha}
            };

            bool cadastrado = c.ManutencaoDB(comando_sql, paramsList);

            if (cadastrado)
            {
                inputNome.Value = "";
                inputCPF.Value = "";
                inputDDD.Value = "";
                inputCelular.Value = "";
                inputEmail.Value = "";

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