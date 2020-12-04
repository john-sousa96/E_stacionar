using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstacionamento
{
    public partial class account_settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=account-settings.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                if (!IsPostBack)
                {
                    // oculta o botão login da navbar
                    template mPage = (template)Page.Master;
                    mPage.FindControl("botao_login").Visible = false;

                    // preenche o nome do usuario logado no dropdown
                    Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                    menu_nome_logado.Text = Session["user_nome"].ToString();
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            String s;

            s = inputUsername.Value;
            s = s + ", " + inputNome.Value;
            s = s + ", " + inputEmail.Value;
            s = s + ", " + inputCompany.Value;

            System.Diagnostics.Debug.WriteLine(s);

        }
    }
}