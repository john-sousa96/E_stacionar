using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] != null) && ((int)Session["bool_logado"] == 1))
            {
                // caso um usuario esteja logado, será redirecionado para o dashboard
                Response.Redirect("dashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                // caso não haja usuario logado, ocultará botões da navbar
                template mPage = (template)Page.Master;
                mPage.FindControl("botao_painel").Visible = false;
                mPage.FindControl("menu_usuario").Visible = false;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtLogin.Text.Trim().Replace(".","").Replace("-","").Replace("/","");
            pass = txtSenha.Text.Trim();

            string hash = CryptoHash.Encriptar(user + pass);

            DataTable dt;
            Conexao c = new Conexao();

            string comando_sql = "SELECT * FROM (" +
                "SELECT nome_usuario AS nome, id_CPF_usuario AS usuario,senha_usuario AS senha,permissao FROM tbl_usuario " +
                "UNION SELECT nome_empresa AS nome, id_cnpj_empresa AS usuario,senha_empresa AS senha,permissao FROM tbl_empresa " +
                "UNION SELECT nome_completo_func AS nome, CPF_func AS usuario, senha_func AS senha, permissao FROM tbl_funcionario_est) " +
                "AS logins WHERE usuario=@user AND senha=@pass";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@user", SqlDbType.VarChar) {Value = user},
                new SqlParameter("@pass", SqlDbType.VarChar) {Value = hash},
            };

            dt = c.ExecutarSQL(comando_sql, paramsList);

            if ((int)Convert.ToInt32(dt.Rows.Count) > 0)
            {
                // caso logado com sucesso guarda dados na Session
                string nome = dt.DefaultView[0].Row["nome"].ToString();
                string usuario = dt.DefaultView[0].Row["usuario"].ToString();
                string permissao = dt.DefaultView[0].Row["permissao"].ToString();

                Session["bool_logado"] = 1;
                Session["user_nome"] = nome;
                Session["cpfcnpj"] = usuario;
                Session["user_perm"] = permissao;

                // verifica se há redirecionamento para alguma página específica,
                // caso contrário redireciona para o painel principal
                string strRedirect = Request["ReturnUrl"] ?? "dashboard.aspx";
                Response.Redirect(strRedirect, false);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarLoginFalhou", "AlertarLoginFalhou()", true);
            }
        }
    }
}