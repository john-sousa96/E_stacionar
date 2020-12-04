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
    public partial class gerenciar_reservas : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.grdView.RowCommand += GridView1_RowCommand;
        }

        private void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                txtIdSelecionado.Value = Master.grdView.DataKeys[rowIndex].Value.ToString();

                if (e.CommandName.Equals("editRegistro"))
                {
                    System.Diagnostics.Debug.WriteLine(txtIdSelecionado.Value);
                    System.Diagnostics.Debug.WriteLine(e.CommandName);
                }
                else if (e.CommandName.Equals("deletarRegistro"))
                {
                    ShowHideModalScript("ModalConfirmarExclusao", true);
                }

                // Chama a função js para recarregar a tabela (DataTables) na pagina pois ocorre um postback
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CarregarTabela", "CarregarTabela();", true);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro RowCommand: {ex}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=gerenciar-reservas.aspx", false);
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
                else
                {
                    // oculta botoes da navbar
                    template mPage = (template)Page.Master.Master;
                    mPage.FindControl("botao_login").Visible = false;

                    // preenche o nome do usuario logado no dropdown
                    Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                    menu_nome_logado.Text = Session["user_nome"].ToString();

                    if (!IsPostBack)
                    {
                        BindReservas();
                    }
                }
            }
        }

        private void BindReservas()
        {
            // lista as reservas do usuario
            DataTable dt;
            Conexao c = new Conexao();
            string usuario = Session["cpfcnpj"].ToString();

            string comando_sql = "SELECT R.id_reserva 'Nº Reserva', V.local_vaga Vaga, " +
                "R.timestamp_inicio_reserva Chegada, R.timestamp_final_reserva Saida, " +
                "R.valor_servico_reserva Preço " +
                "FROM tbl_reservas AS R " +
                "INNER JOIN tbl_vaga AS V ON R.tbl_vaga_id_vaga=V.id_vaga " +
                "WHERE R.tbl_usuario_id_CPF_usuario=@usuario " +
                "AND (datediff(hour, R.timestamp_final_reserva, getdate()) <= 0) " +
                "AND R.tbl_token_id_token " +
                "IN (SELECT id_token " +
                "FROM tbl_token " +
                "WHERE status_token=1)";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", SqlDbType.BigInt) {Value = usuario},
            };

            dt = c.ExecutarSQL(comando_sql, paramsList);

            // popula a tabela com os dados
            GridView tabela = Master.grdView;

            tabela.DataSource = dt;
            tabela.DataBind();
            if (dt.Rows.Count > 0)
            {
                tabela.HeaderRow.TableSection = TableRowSection.TableHeader;
                tabela.DataKeyNames = new string[] { "id_reserva" };
            }
            else
            {
                tabela.EmptyDataText = "Você não possui nenhuma reserva em aberto";
                tabela.DataSource = null;
                tabela.DataBind();
            }
        }

        protected void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            string id_reserva = txtIdSelecionado.Value;
            TableData manager = new TableData();
            // apaga a reserva do BD
            bool sucesso = manager.ApagarReserva(id_reserva);

            if (sucesso)
            {
                ShowMessageSuccess("Reserva cancelada com sucesso!");
                BindReservas();
            }
            else
            {
                ShowMessageErrorScript("Ocorreu um erro ao cancelar a reserva. Entre em contato com o suporte!");
            }

            ShowHideModalScript("ModalConfirmarExclusao", false);
            // Chama a função js para recarregar a tabela (DataTables) na pagina pois ocorre um postback
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CarregarTabela", "CarregarTabela();", true);
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
    }
}