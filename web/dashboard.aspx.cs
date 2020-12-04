using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class dashboard : System.Web.UI.Page
    {
        // armazena o id do card a ser destacado pelo js
        public string elementID { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=dashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                // caso um usuario esteja logado
                ControlesUsuario();
            }
        }

        public void ControlesUsuario()
        {
            // oculta botoes da navbar
            template mPage = (template)Page.Master;
            mPage.FindControl("botao_login").Visible = false;

            // preenche o nome do usuario logado no dropdown
            Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
            menu_nome_logado.Text = Session["user_nome"].ToString();
            // header
            header_nome.Text = Session["user_nome"].ToString();
            header_cargo.Text = "";
            header_empresa.Text = "";

            // preenche os valores dos cards
            var dados = new Dashboard();

            numReservas.Text = dados.Reservas;
            numVagas.Text = dados.Vagas;
            numVeiculos.Text = dados.Veiculos;
            numEstacionamentos.Text = dados.Estacionamentos;
            numFuncionarios.Text = dados.Funcionarios;
            numEquipamentos.Text = dados.Equipamentos;
            numServicos.Text = dados.Servicos;
            numUsuarios.Text = dados.Usuarios;
            numEmpresas.Text = dados.Empresas;
            numTokens.Text = dados.Tokens;

            int permissao = Convert.ToInt16(Session["user_perm"].ToString());

            // oculta informações na pagina de acordo com o tipo de usuario logado
            // (2) usuario visualiza: Reservas, Veiculos
            // (3) funcionario visualiza: Reservas, Vagas, Equipamentos, Serviços
            // (4) empresa visualiza: Reservas, Vagas, Estacionamentos, Funcionarios, Equipamentos, Servicos
            // (1) admin master visualiza: Reservas, Vagas, Veiculos, Estacionamentos, Funcionarios, Equipamentos, Serviços, Usuarios, Empresas, Tokens
            if (permissao != 3)
            {
                // se nao for funcionario
                header_cargo.Visible = false;
                header_empresa.Visible = false;
            }

            if (permissao > 1)
            {
                // empresa
                // funcionarios
                // usuario
                card_usuarios.Visible = false;
                card_empresas.Visible = false;
                card_tokens.Visible = false;
            }
            if (permissao == 2)
            {
                // empresa
                card_veiculos.Visible = false;

                if (numEstacionamentos.Text == "0")
                {
                    // armazena o id do card a ser destacado pelo js
                    elementID = $"#BodyContent_{card_estacionamentos.ID}";
                }
                else if (numFuncionarios.Text == "0")
                {
                    // armazena o id do card a ser destacado pelo js
                    elementID = $"#BodyContent_{card_funcionarios.ID}";
                }
                else if (numEquipamentos.Text == "0")
                {
                    // armazena o id do card a ser destacado pelo js
                    elementID = $"#BodyContent_{card_equipamentos.ID}";
                }
                else if (numServicos.Text == "0")
                {
                    // armazena o id do card a ser destacado pelo js
                    elementID = $"#BodyContent_{card_servicos.ID}";
                }
                else if (numVagas.Text == "0")
                {
                    // armazena o id do card a ser destacado pelo js
                    elementID = $"#BodyContent_{card_vagas.ID}";
                }
            }
            if (permissao == 3)
            {
                // funcionario
                card_veiculos.Visible = false;
                card_funcionarios.Visible = false;
                card_estacionamentos.Visible = false;
            }
            if (permissao == 4)
            {
                // usuario
                card_vagas.Visible = false;
                card_estacionamentos.Visible = false;
                card_funcionarios.Visible = false;
                card_equipamentos.Visible = false;
                card_servicos.Visible = false;

                if (numVeiculos.Text == "0")
                {
                    // armazena o id do card a ser destacado pelo js
                    elementID = $"#BodyContent_{card_veiculos.ID}";
                }
            }
        }
    }
}