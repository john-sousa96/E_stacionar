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
    
    public partial class form_relatorio_func : Form
    {   

        public form_relatorio_func()
        {
            InitializeComponent();
        }
        

        private void cbox_relatorio_func_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbox_relatorio_func.SelectedIndex;
            
            String sql;
            

            
            conexao c = new conexao();
            if (c.connect() == true)
            {

                try
                {
                    SqlDataAdapter dAdapter = new SqlDataAdapter();
                    DataSet dt = new DataSet();
                    c.connect();

                    if (selectedIndex == 1)
                    {
                        btn_Consultar_Veiculo.Visible = true;
                        sql = "Select U.id_nota_fiscal_uso, U.valor_servico_uso, U.timestamp_inicio_uso, U.timestamp_final_uso, (DATEDIFF(MINUTE, U.timestamp_inicio_uso, CURRENT_TIMESTAMP) * (U.valor_servico_uso/60)) as total, C.nome_usuario, S.desc_servico,v.local_vaga, R.id_placa_veiculo from tbl_uso as U inner join tbl_usuario as C on U.tbl_usuario_id_CPF_usuario = C.id_CPF_usuario inner join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico inner join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga inner join tbl_veiculos as R on U.tbl_token_id_token = R.tbl_token_id_token where timestamp_final_uso is null";
                        c.command.CommandText = sql;

                        dAdapter.SelectCommand = c.command;
                        dAdapter.Fill(dt);
                        c.fechaConexao();
                        dataGridRelatorio.DataSource = dt.Tables[0];
                    }
                    else
                    {
                        btn_Consultar_Veiculo.Visible = false;
                        dataGridVeiculos.Visible = false;
                    }
                    if (selectedIndex == 2)
                    {
                        btn_Consultar_Veiculo.Visible = false;
                        sql = "Select U.id_nota_fiscal_uso, U.valor_servico_uso, U.timestamp_inicio_uso, U.timestamp_final_uso, (DATEDIFF(MINUTE, U.timestamp_inicio_uso, CURRENT_TIMESTAMP) * (U.valor_servico_uso/60)) as total, C.nome_usuario, S.desc_servico,v.local_vaga, R.id_placa_veiculo from tbl_uso as U inner join tbl_usuario as C on U.tbl_usuario_id_CPF_usuario = C.id_CPF_usuario inner join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico inner join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga inner join tbl_veiculos as R on U.tbl_token_id_token = R.tbl_token_id_token where datediff(hour, timestamp_final_uso, CURRENT_TIMESTAMP) <= 24";
                        c.command.CommandText = sql;

                        dAdapter.SelectCommand = c.command;
                        dAdapter.Fill(dt);
                        c.fechaConexao();
                        dataGridRelatorio.DataSource = dt.Tables[0];
                    }


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
            Placa = dataGridRelatorio.CurrentCell.Value.ToString();

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

        private void dataGridRelatorio_SelectionChanged(object sender, EventArgs e)
        {
            dataGridVeiculos.Visible = false;
        }
    }
}
