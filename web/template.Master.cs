using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebEstacionamento
{
    public partial class template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // finaliza a sessão do usuario e redireciona para a pagina principal do site
            Session.Abandon();
            Response.Redirect("index.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}