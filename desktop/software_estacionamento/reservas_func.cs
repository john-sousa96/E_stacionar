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

namespace software_estacionamento
{
    public partial class reservas_func : Form
    {
        public reservas_func()
        {
            InitializeComponent();
            conexao c = new conexao();
            if (c.connect() == true)
            {

                try
                {
                    SqlDataAdapter dAdapter = new SqlDataAdapter();
                    DataSet dt = new DataSet();
                    c.connect();
                    String sql;



                    sql = "Select R.id_reserva, R.timestamp_inicio_reserva, R.timestamp_final_reserva, S.desc_servico, V.local_vaga, C.id_placa_veiculo, U.nome_usuario,  (DATEDIFF(hour, R.timestamp_inicio_reserva, R.timestamp_final_reserva) * R.valor_servico_reserva) as subtotal from tbl_reservas as R inner join tbl_usuario as U on R.tbl_usuario_id_CPF_usuario  = U.id_CPF_usuario inner join tbl_servico as S on R.tbl_servico_id_servico = S.id_servico inner join tbl_vaga as V on R.tbl_vaga_id_vaga = V.id_vaga inner join tbl_veiculos as C on R.tbl_token_id_token = C.tbl_token_id_token where datediff(hour, timestamp_final_reserva, CURRENT_TIMESTAMP) <= 24";
                   
                    c.command.CommandText = sql;

                    dAdapter.SelectCommand = c.command;
                    dAdapter.Fill(dt);
                    c.fechaConexao();
                    dataGridView1.DataSource = dt.Tables[0];



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha" + ex);
                }
            }
        }

        private void btn_Consultar_Veiculo_Click(object sender, EventArgs e)
        {
            String Placa;
            Placa = dataGridView1.CurrentCell.Value.ToString();

            dataGridVeiculos.Visible = true;

            conexao c = new conexao();
            if (c.connect() == true)
            {

                try
                {
                    SqlDataAdapter dAdapter = new SqlDataAdapter();
                    DataSet dt = new DataSet();
                    c.connect();

                    String sql = "select * from tbl_veiculos where id_placa_veiculo= '" + Placa + "'";
                    c.command.CommandText = sql;
                    dAdapter.SelectCommand = c.command;
                    dAdapter.Fill(dt);
                    c.fechaConexao();
                    dataGridVeiculos.DataSource = dt.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha" + ex);
                }
            }
        }
    }
}
