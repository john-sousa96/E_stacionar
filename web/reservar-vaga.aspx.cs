using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebEstacionamento.App_Code;

namespace WebEstacionamento
{
    public partial class reservar_vaga : System.Web.UI.Page
    {
        private DataTable dt;
        private Conexao c = new Conexao();

        public string Estacionamentos { get; private set; }
        public string VagasLivres { get; private set; }
        public string ServicosVagas { get; private set; }

        private DataTable getEstacionamentos()
        {
            // retorna um DataTable com os estacionamentos ativos
            DataTable dt;
            Conexao c = new Conexao();

            string comando_sql = "SELECT EM.nome_empresa, ES.id_estacionamento, ES.logradouro_est, ES.numero_est, ES.complemento_est, " +
                "ES.CEP_est, ES.cidade_est, ES.estado_est, ES.ddd_tel_est, ES.tel_est, ES.ramal_est, ES.lat_est, ES.lng_est, " +
                "(SELECT COUNT(status_vaga) FROM tbl_vaga WHERE status_vaga = 1 AND tbl_estacionamento_id_estacionamento = ES.id_estacionamento) AS vagas_livres, " +
                "(SELECT COUNT(status_vaga) FROM tbl_vaga WHERE status_vaga = 0 AND tbl_estacionamento_id_estacionamento = ES.id_estacionamento) AS vagas_ocupadas " +
                "FROM tbl_estacionamento AS ES " +
                "INNER JOIN tbl_empresa AS EM ON ES.tbl_empresa_id_cnpj_empresa = EM.id_cnpj_empresa " +
                "WHERE ES.status_est = 1";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            dt = c.ExecutarSQL(comando_sql, paramsList);
            return dt;
        }

        private DataTable getVagasLivres()
        {
            // retorna um DataTable com as vagas livres
            DataTable dt;
            Conexao c = new Conexao();

            string comando_sql = "SELECT E.id_estacionamento, V.id_vaga, V.local_vaga FROM tbl_vaga AS V " +
                "INNER JOIN tbl_estacionamento AS E ON V.tbl_estacionamento_id_estacionamento = E.id_estacionamento " +
                "WHERE V.status_vaga = 1";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            dt = c.ExecutarSQL(comando_sql, paramsList);
            return dt;
        }

        private DataTable getServicosVagas()
        {
            // retorna um DataTable com os serviços associados às vagas livres
            DataTable dt;
            Conexao c = new Conexao();

            string comando_sql = "SELECT V.id_vaga, S.desc_servico, S.valor_servico FROM tbl_vaga AS V " +
                "INNER JOIN tbl_servico_vaga AS SV ON V.id_vaga = SV.tbl_vaga_id_vaga " +
                "INNER JOIN tbl_servico AS S ON SV.tbl_servico_id_servico = S.id_servico " +
                "WHERE V.status_vaga = 1";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            dt = c.ExecutarSQL(comando_sql, paramsList);
            return dt;
        }

        private string DataTable_JSON_JsonNet(DataTable tabela)
        {
            try
            {
                string jsonString = string.Empty;
                jsonString = JsonConvert.SerializeObject(tabela);
                return jsonString;
            }
            catch
            {
                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["bool_logado"] == null) || ((int)Session["bool_logado"] != 1))
            {
                // caso nao haja usuario logado redireciona para a pagina login com return para essa página
                Response.Redirect("login.aspx?ReturnUrl=reservar-vaga.aspx", false);
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
                    template mPage = (template)Page.Master;
                    mPage.FindControl("botao_login").Visible = false;

                    // preenche o nome do usuario logado no dropdown
                    Literal menu_nome_logado = (Literal)(mPage).FindControl("menu_nome_logado");
                    menu_nome_logado.Text = Session["user_nome"].ToString();

                    DataTable dt = getEstacionamentos();
                    string json_est = DataTable_JSON_JsonNet(dt);
                    Estacionamentos = json_est;

                    dt = getVagasLivres();
                    string json_vagas = DataTable_JSON_JsonNet(dt);
                    VagasLivres = json_vagas;

                    dt = getServicosVagas();
                    string json_servicos = DataTable_JSON_JsonNet(dt);
                    ServicosVagas = json_servicos;

                    if (!IsPostBack)
                    {
                        Fill_Estacionamento();
                    }
                }
            }
        }

        private void Fill_Estacionamento()
        {
            string usuario = Session["cpfcnpj"].ToString();

            // lista os veículos do usuario logado que estão com token ativo
            string comando_sql = "SELECT id_placa_veiculo, modelo_veiculo " +
                "FROM tbl_veiculos " +
                "WHERE id_placa_veiculo " +
                "IN (SELECT id_placa_veiculo " +
                "FROM tbl_user_veiculo " +
                "WHERE id_CPF_usuario=@usuario) " +
                "AND tbl_token_id_token " +
                "IN (SELECT id_token " +
                "FROM tbl_token " +
                "WHERE status_token=1) " +
                "ORDER BY id_placa_veiculo ASC";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@usuario", SqlDbType.VarChar) {Value = usuario},
            };

            try
            {
                dt = c.ExecutarSQL(comando_sql, paramsList);

                int qtdVeiculos = dt.Rows.Count;

                // caso a lista de estacionamento esteja vazia
                if (qtdVeiculos == 0)
                {
                    // altera o conteudo da lista e o title do dropdown
                    inputVeiculo.Items.Insert(0, new ListItem("Você não possui veículos", "0"));
                    inputVeiculo.ToolTip = "Você não possui nenhum veículo cadastrado.";

                    // bloqueia os campos para preenchimento
                    inputVaga.Enabled = false;
                    datepicker_inicial.Disabled = true;
                    datepicker_final.Disabled = true;
                    btnConfirmarReserva.Enabled = false;

                    // exibe um alerta com link para a pagina de cadastro de estacionamentos
                    string msgText = "Você precisa cadastrar um veículo antes de realizar uma reserva." +
                        "<hr><a href='./cadastro-veiculo.aspx' class='alert-link'>Clique aqui</a> para cadastrar um veículo.";

                    string jsFunction = $"AlertarCamposInvalidos(\"{msgText.Trim()}\");";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCamposInvalidos", jsFunction, true);
                }
                else
                {
                    // popula a lista com o endereço concatenado de cada estacionamento que a empresa possui
                    inputVeiculo.Items.Insert(0, new ListItem("Escolha um veículo...", "0"));

                    for (int i = 0; i < qtdVeiculos; i++)
                    {
                        string id = dt.Rows[i]["id_placa_veiculo"].ToString();
                        string modelo = dt.Rows[i]["modelo_veiculo"].ToString();

                        string item = $"{id} ({modelo})";

                        inputVeiculo.Items.Insert(i + 1, new ListItem(item, id.ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                // caso ocorra algum erro no SQL, printa a mensagem de erro e manda um aviso genérico ao usuario

                System.Diagnostics.Debug.WriteLine($"Erro ao preencher a lista de veículos: {e}");

                string msgText = "Ocorreu um erro ao carregar a página. Por favor, recarregue a página e tente novamente." +
                    "<hr>Caso o erro persista, entre em contato conosco.";

                string jsFunction = $"AlertarCamposInvalidos(\"{msgText.Trim()}\");";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertarCamposInvalidos", jsFunction, true);
            }
        }


        protected void btnConfirmarReserva_Click(object sender, EventArgs e)
        {

        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            // se todos os dados inseridos forem válidos, chamará um método para armazenar no BD
            if (ValidarDadosInseridos())
            {
                System.Diagnostics.Debug.WriteLine("validado");
                // SalvarDadosBD();
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

            if (inputVaga.SelectedItem.Text.Equals("Escolha uma vaga...") || inputVaga.SelectedItem.Text.Equals("") || inputVaga.Text.Equals("0"))
            {
                ValidacaoBootstrap(inputVaga.ID, "false");
                msgText = "<p>&#149; Por favor, selecione uma <mark>Vaga</mark> na lista.</p>";
                errorsCount += 1;
            }

            // Datepicker Inicio
            if (datepicker_inicial.Value.Equals(""))
            {
                ValidacaoBootstrap(datepicker_inicial.ID, "false");
                msgText += "<p>&#149; Por favor, insira <mark>Data e Hora de Chegada</mark> no padrão (dd/mm/aaaa hh:mm).</p>";
                errorsCount += 1;
            }
            else
            {
                DateTime dataInicio;
                try
                {
                    string d = datepicker_inicial.Value.Replace("T", " ");
                    dataInicio = DateTime.ParseExact(d, @"yyyy-MM-dd HH:mm", CultureInfo.GetCultureInfo("pt-BR"));
                }
                catch (Exception)
                {
                    ValidacaoBootstrap(datepicker_inicial.ID, "false");
                    msgText += "<p>&#149; Por favor, insira <mark>Data e Hora de Chegada</mark> no padrão (dd/mm/aaaa hh:mm).</p>";
                    errorsCount += 1;
                }
            }

            // Datepicker Final
            if (datepicker_final.Value.Equals(""))
            {
                ValidacaoBootstrap(datepicker_final.ID, "false");
                msgText += "<p>&#149; Por favor, insira <mark>Data e Hora de Saída</mark> no padrão (dd/mm/aaaa hh:mm).</p>";
                errorsCount += 1;
            }
            else
            {
                DateTime dataFinal;
                try
                {
                    string d = datepicker_final.Value.Replace("T", " ");
                    dataFinal = DateTime.ParseExact(d, @"yyyy-MM-dd HH:mm", CultureInfo.GetCultureInfo("pt-BR"));
                }
                catch (Exception)
                {
                    ValidacaoBootstrap(datepicker_final.ID, "false");
                    msgText += "<p>&#149; Por favor, insira <mark>Data e Hora de Saída</mark> no padrão (dd/mm/aaaa hh:mm).</p>";
                    errorsCount += 1;
                }
            }

            if (inputVeiculo.SelectedItem.Text.Equals("Escolher...") || inputVeiculo.SelectedItem.Text.Equals("") || inputVeiculo.Text.Equals("0"))
            {
                ValidacaoBootstrap(inputVeiculo.ID, "false");
                msgText += "<p>&#149; Por favor, selecione um <mark>Veículo</mark> na lista.</p>";
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

        public void ValidacaoBootstrap(string element, string booleano)
        {
            element = $"BodyContent_{element}";
            // chama função javascript (main.js) para alterar a classe de validação do bootstrap
            string jsFunction = $"ValidarCampo({element},{booleano});";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidarCampo", jsFunction, true);
        }

        private void ShowHideModalScript(string modal, bool status)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#" + modal + "').modal('" + (status ? "show" : "hide") + "');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "startScript", sb.ToString(), false);
        }

        [System.Web.Services.WebMethod]
        public void GetDetails(string id_est)
        {
            // System.Diagnostics.Debug.WriteLine("Lat: " + lat);
            // System.Diagnostics.Debug.WriteLine("Long: " + lng);

            try
            {
                dt = getVagasLivres();

                // popula a lista com o endereço concatenado de cada estacionamento que a empresa possui
                string filtro = $"id_estacionamento = {id_est}";
                DataView dsFiltrado = dt.DefaultView;
                dsFiltrado.RowFilter = filtro;
                var newDS = new DataSet();
                newDS.Tables.Add(dsFiltrado.ToTable());
                inputVaga.DataValueField = "id_estacionamento";
                inputVaga.DataTextField = "local_vaga";
                inputVaga.DataSource = newDS;
                inputVaga.DataBind();
                inputVaga.Items.Insert(0, new ListItem("Escolha uma vaga...", "0"));
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
    }
}