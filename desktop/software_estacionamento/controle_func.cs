using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data.Sql;
using System.Data.SqlServerCe;
using System.Linq.Expressions;

namespace software_estacionamento
{
    public partial class controle_func : Form
    {
       


        

        public controle_func()
        {
            InitializeComponent();
            Carregar();


        }

        public void Carregar()
        {
            conexao c = new conexao();
            String sql;

            if (c.connect() == true)
            {

                try
                {
                    SqlDataAdapter dAdapter = new SqlDataAdapter();
                    DataSet dt = new DataSet();
                    c.connect();


                    sql = "Select Distinct (V.local_vaga), V.status_vaga, U.id_nota_fiscal_uso, U.timestamp_inicio_uso,U.timestamp_final_uso, U.valor_servico_uso, S.desc_servico, R.id_placa_veiculo, (DATEDIFF(MINUTE, U.timestamp_inicio_uso, CURRENT_TIMESTAMP) * (U.valor_servico_uso/60)) as subtotal from tbl_vaga as V  left join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento left join tbl_uso as U on V.id_vaga = U.tbl_vaga_id_vaga  left join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico left join tbl_veiculos as R on U.tbl_token_id_token = R.tbl_token_id_token where F.id_func = 1 and U.timestamp_final_uso is null order by V.local_vaga asc";
                    c.command.CommandText = sql;

                    dAdapter.SelectCommand = c.command;
                    dAdapter.Fill(dt);

                    c.fechaConexao();
                    dataGridControle.DataSource = dt.Tables[0];
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Falha" + ex);
                }

            }
        }

        private void btn_corrigir_func_Click(object sender, EventArgs e)
        {

            panel_adicionar_update.Visible = true;
            bt_confirmar_correcao.Visible = true;
            bt_cancelar_correcao.Visible = true;


            btn_adicionar_uso.Visible = false;
            btn_corrigir.Visible = false;
            btn_update_status_vaga.Visible = false;

            /*conexao c = new conexao();
            if (c.connect() == true)
            {

                try
                {
                    int NotaFiscal;
                    NotaFiscal = Convert.ToInt32(dataGridControle.SelectedRows[0].Cells[0].Value);



                    String s;
                    s = Microsoft.VisualBasic.Interaction.InputBox("Digite novo valor:");
                    c.connect();

                    c.command.CommandText = "update tbl_uso set senha=@s where codigo=@codUsuario";
                    c.command.Parameters.Add("@codUsuario", SqlDbType.Int).Value = NotaFiscal;
                    c.command.Parameters.Add("@s", SqlDbType.VarChar).Value = s;
                    c.command.ExecuteNonQuery();

                    c.fechaConexao();

                    Carregar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha");
                }




            }*/
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_update_status_vaga_Click(object sender, EventArgs e)
        {
            panel_atualizar.Visible = true;
            btn_atualizar_vaga.Visible = true;
            btn_cancelar_status.Visible = true;

            btn_adicionar_uso.Visible = false;
            btn_corrigir.Visible = false;
            btn_update_status_vaga.Visible = false;

            fillcombox();
        }

        private void btn_adicionar_uso_Click(object sender, EventArgs e)
        {
            panel_adicionar_update.Visible = true;
            btn_confirmar_novo.Visible = true;
            bt_cancelar_novo.Visible = true;

            btn_adicionar_uso.Visible = false;
            btn_corrigir.Visible = false;
            btn_update_status_vaga.Visible = false;

        }

        private void btn_cancelar_status_Click(object sender, EventArgs e)
        {
            panel_atualizar.Visible = false;
            btn_atualizar_vaga.Visible = false;
            btn_cancelar_status.Visible = false;

            btn_adicionar_uso.Visible = true;
            btn_corrigir.Visible = true;
            btn_update_status_vaga.Visible = true;
        }

        private void bt_cancelar_novo_Click(object sender, EventArgs e)
        {
            panel_adicionar_update.Visible = false;
            btn_confirmar_novo.Visible = false;
            bt_cancelar_novo.Visible = false;

            btn_adicionar_uso.Visible = true;
            btn_corrigir.Visible = true;
            btn_update_status_vaga.Visible = true;
        }

        private void bt_cancelar_correcao_Click(object sender, EventArgs e)
        {
            panel_adicionar_update.Visible = false;
            bt_confirmar_correcao.Visible = false;
            bt_cancelar_correcao.Visible = false;


            btn_adicionar_uso.Visible = true;
            btn_corrigir.Visible = true;
            btn_update_status_vaga.Visible = true;

        }

        public void fillcombox()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-P3ARQEH;Initial Catalog=bd_estacionamentos;Persist Security Info=True;User ID=sa;Password=abc1234");
            String sql = "Select Distinct(V.local_vaga) from tbl_vaga as V left join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento left join tbl_uso as U on U.tbl_vaga_id_vaga = V.id_vaga where F.id_func = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while(myreader.Read())
                {
                    String lvaga = myreader.GetString(0);
                    cb_vaga.Items.Add(lvaga);
                }
               
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
