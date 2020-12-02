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
using System.Linq.Expressions;

namespace software_estacionamento
{
    public partial class controle_func : Form
    {





        public controle_func()
        {
            InitializeComponent();
            Carregar();
            CarregarLivres();


        }

        public void Carregar()
        {
            conexao c = new conexao();
            String sql;

            if (c.connect() == true)
            {

                try
                {

                    dataGridControle.DataSource = null;
                    dataGridControle.Refresh();
                    SqlDataAdapter dAdapter = new SqlDataAdapter();
                    DataSet dt = new DataSet();
                    c.connect();



                    sql = "Select V.local_vaga, iif(U.timestamp_final_uso is not null,null,U.id_placa_veiculo) as id_placa_veiculo , V.status_vaga, iif(U.timestamp_final_uso is not null,null,U.id_nota_fiscal_uso) as id_nota_fiscal_uso, iif(U.timestamp_final_uso is not null,null,U.timestamp_inicio_uso) as timestamp_inicio_uso, iif(U.timestamp_final_uso is not null,null,S.desc_servico) as desc_servico from tbl_uso as U right join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga left join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento and F.id_func = 1 order by local_vaga";
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

        private void CarregarLivres()
        {
            conexao c = new conexao();
            String sql;

            if (c.connect() == true)
            {

                try
                {

                    dataGridLivres.DataSource = null;
                    dataGridLivres.Refresh();
                    SqlDataAdapter dAdapter = new SqlDataAdapter();
                    DataSet dt = new DataSet();
                    c.connect();


                    sql = "Select Distinct (V.local_vaga), V.status_vaga from tbl_vaga as V left join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento left join tbl_uso as U on U.tbl_vaga_id_vaga = V.id_vaga where F.id_func = 1  and V.status_vaga = 0 order by V.local_vaga asc";
                    c.command.CommandText = sql;

                    dAdapter.SelectCommand = c.command;
                    dAdapter.Fill(dt);

                    c.fechaConexao();
                    dataGridLivres.DataSource = dt.Tables[0];
                   

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
            panel_atualizar.Visible = true;
            bt_confirmar_correcao.Visible = true;
            bt_cancelar_correcao.Visible = true;


            btn_adicionar_uso.Visible = false;
            btn_corrigir.Visible = false;
            btn_update_status_vaga.Visible = false;
            ck_uso.Enabled = true;
            cb_status.Enabled = false;

            cb_minutos_final.Enabled = true;
            cb_hora_final.Enabled = true;
            ck_pegar_horario_final.Enabled = true;

            fillcomboxServico();

           
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
            cb_vaga.Enabled = true;

            btn_adicionar_uso.Visible = false;
            btn_corrigir.Visible = false;
            btn_update_status_vaga.Visible = false;
                       
            fillcombox();
        }

        private void btn_adicionar_uso_Click(object sender, EventArgs e)
        {
            panel_adicionar_update.Visible = true;
            panel_atualizar.Visible = true;
            btn_confirmar_novo.Visible = true;
            bt_cancelar_novo.Visible = true;
          

            btn_adicionar_uso.Visible = false;
            btn_corrigir.Visible = false;
            btn_update_status_vaga.Visible = false;
            cb_status.Enabled = false;
            cb_minutos_final.Enabled = false;
            cb_hora_final.Enabled = false;
            ck_pegar_horario_final.Enabled = false;
            ck_uso.Enabled = false;
            
            fillcombox();
            fillcomboxServico();
            /*if (cb_hora_inicial.Text!="")
            {
                cb_hora_inicial.Items.Clear();
                cb_hora_final.Items.Clear();
                cb_minuto_inicial.Items.Clear();
                cb_minutos_final.Items.Clear();
            }*/
            
            
            cb_hora_inicial.DataSource = Enumerable.Range(00, 24).ToList();
            cb_hora_final.DataSource = Enumerable.Range(00, 24).ToList();
            cb_minuto_inicial.DataSource = Enumerable.Range(00, 60).ToList();
            cb_minutos_final.DataSource = Enumerable.Range(00, 60).ToList();

          
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
            panel_atualizar.Visible = false;
            btn_confirmar_novo.Visible = false;
            bt_cancelar_novo.Visible = false;

            btn_adicionar_uso.Visible = true;
            btn_corrigir.Visible = true;
            btn_update_status_vaga.Visible = true;
            cb_status.Enabled = true;
            cb_minutos_final.Enabled = true;
            cb_hora_final.Enabled = true;
            ck_pegar_horario_final.Enabled = true;
            ck_uso.Enabled = true;
        }

        private void bt_cancelar_correcao_Click(object sender, EventArgs e)
        {
            panel_adicionar_update.Visible = false;
            panel_atualizar.Visible = false;
            bt_confirmar_correcao.Visible = false;
            bt_cancelar_correcao.Visible = false;


            btn_adicionar_uso.Visible = true;
            btn_corrigir.Visible = true;
            btn_update_status_vaga.Visible = true;
            cb_status.Enabled = true;

        }

        public void fillcombox()
        {
            cb_vaga.Items.Clear();
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

        public void fillcomboxServico()
        {
            cb_servico.Items.Clear();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-P3ARQEH;Initial Catalog=bd_estacionamentos;Persist Security Info=True;User ID=sa;Password=abc1234");
            String sql = "Select Distinct(S.desc_servico) from tbl_Servico as S left join tbl_funcionario_est as F on S.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento  where F.id_func = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    String Servico = myreader.GetString(0);
                    cb_servico.Items.Add(Servico);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_atualizar_vaga_Click(object sender, EventArgs e)
        {


            if (cb_status.Text == "" || cb_vaga.Text == "")
            {
                MessageBox.Show("Por favor, selecione uma vaga e o status (livre ou ocupado) dessa vaga!");
            }
            else
            {
                String Vaga, placa;
                Vaga = cb_vaga.Text;

                int status;
                if (cb_status.Text == "Livre")
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
                            sql = "Select count(U.id_placa_veiculo) as qtd from tbl_uso as U inner join tbl_vaga as Va on U.tbl_vaga_id_vaga = Va.id_vaga inner join tbl_estacionamento as E on Va.tbl_estacionamento_id_estacionamento = E.id_estacionamento inner join tbl_funcionario_est as F on E.id_estacionamento = F.tbl_estacionamento_id_estacionamento where Va.local_vaga = '" + Vaga + "' and F.id_func = 1 and U.timestamp_final_uso is Null";
                            c.command.CommandText = sql;

                            dAdapter.SelectCommand = c.command;
                            dAdapter.Fill(dt);

                            if ((int)dt.Tables[0].DefaultView[0].Row["qtd"] > 0)
                            {

                                c.command.CommandText = "update tbl_vaga set status_vaga = 0 where id_vaga in (Select id_vaga from tbl_vaga where local_vaga = '" + Vaga + "' and tbl_estacionamento_id_estacionamento in (Select tbl_estacionamento_id_estacionamento from tbl_funcionario_est where id_func = 1))";
                                c.command.ExecuteNonQuery();
                                c.command.CommandText = "update tbl_uso set timestamp_final_uso = CURRENT_TIMESTAMP  where tbl_vaga_id_vaga in (Select id_vaga from tbl_vaga where local_vaga = '" + Vaga + "' and tbl_estacionamento_id_estacionamento in (Select tbl_estacionamento_id_estacionamento from tbl_funcionario_est where id_func = 1)) and status_vaga = 1";
                                c.command.ExecuteNonQuery();
                                c.fechaConexao();
                                Carregar();
                                CarregarLivres();


                            }
                            else
                            {
                                c.command.CommandText = "update tbl_vaga set status_vaga = 0 where id_vaga in (Select id_vaga from tbl_vaga where local_vaga = '" + Vaga + "' and tbl_estacionamento_id_estacionamento in (Select tbl_estacionamento_id_estacionamento from tbl_funcionario_est where id_func = 1))";
                                c.command.ExecuteNonQuery();
                                c.fechaConexao();
                                Carregar();
                                CarregarLivres();


                            }

                            MessageBox.Show("Status da vaga foi atualizado!");


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (cb_status.Text == "Ocupado")
                {
                    conexao c = new conexao();
                    
                    if (c.connect() == true)
                    {

                        try
                        {

                            c.command.CommandText = "update tbl_vaga set status_vaga = 1 where id_vaga in (Select id_vaga from tbl_vaga where local_vaga = '" + Vaga + "' and tbl_estacionamento_id_estacionamento in (Select tbl_estacionamento_id_estacionamento from tbl_funcionario_est where id_func = 1))";
                            c.command.ExecuteNonQuery();
                            c.fechaConexao();
                            MessageBox.Show("Status da vaga foi atualizado!");
                            Carregar();
                            CarregarLivres();
                            inicial();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }


                }
            }
        }

        private void dataGridControle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridControle.Columns[e.ColumnIndex].Name.Equals("status_vaga"))
            {
                int? status_vaga = e.Value as int?;

                
                if (status_vaga == 0)
                {
                    e.Value = "Livre";
                }
                else if (status_vaga == 1)
                {
                    e.Value = "Ocupado";
                }
                
            }
        }

        private void dataGridLivres_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridLivres.Columns[e.ColumnIndex].Name.Equals("status_vaga"))
            {
                int? status_vaga = e.Value as int?;

               
                if (status_vaga == 0)
                {
                    e.Value = "Livre";
                }
                else if (status_vaga == 1)
                {
                    e.Value = "Ocupado";
                }

            }


        }

        private void btn_confirmar_novo_Click(object sender, EventArgs e)
        {
            if (cb_vaga.Text == ""  || txt_placa.Text == "" || cb_servico.Text == "" || cb_hora_inicial.Text == "" || cb_minuto_inicial.Text == "")
            {
                MessageBox.Show("Por favor, preencha os campos Vaga, status da vaga, Placa do veículo, serviço prestado e horário inicial");
            }
            else
            {
                conexao c = new conexao();

                if (c.connect() == true)
                {

                    try
                    {
                        String vaga = cb_vaga.Text;
                        String Placa = txt_placa.Text.Trim();
                        String servico = cb_servico.Text;
                        String HorarioInicial;
                        string Date = DateTime.Now.ToString("yyyy-MM-dd");
                      
                        if (ck_pegar_horario_iniclal.Checked == true)
                        {
                            HorarioInicial = DateAndTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {
                             
                            String hora1 = cb_hora_inicial.Text;
                            if(hora1== "0"|| hora1 == "1" || hora1 == "2" || hora1 == "3" || hora1 == "4" || hora1 == "5" || hora1 == "6" || hora1 == "7" || hora1 == "8" || hora1 == "9")
                            {
                                hora1 = "0" + hora1;
                            }

                            String minutos1 = cb_minuto_inicial.Text;
                            if (minutos1 == "0" || minutos1 == "1" || minutos1 == "2" || minutos1 == "3" || minutos1 == "4" || minutos1 == "5" || minutos1 == "6" || minutos1 == "7" || minutos1 == "8" || minutos1 == "9")
                            {
                                minutos1 = "0" + minutos1;
                            }
                            HorarioInicial = Date + " " + hora1 + ":" + minutos1;

                        }
                       
                       
                        SqlDataAdapter dAdapter = new SqlDataAdapter();
                        DataSet dt = new DataSet();
                        c.connect();
                        c.command.CommandText = "exec usp_inserir_manualmente 1, '"+ vaga +"', '"+Placa+"', '"+servico+"', '"+HorarioInicial+"'";
                        c.command.ExecuteNonQuery();
                        c.fechaConexao();
                        Carregar();
                        CarregarLivres();
                        MessageBox.Show("Dados inseridos com sucesso");
                        inicial();






                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void ck_pegar_horario_iniclal_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_pegar_horario_iniclal.Checked == true)
            {
                cb_hora_inicial.Enabled = false;
                cb_minuto_inicial.Enabled = false;
            }
            else
            {
                cb_hora_inicial.Enabled = true;
                cb_minuto_inicial.Enabled = true;
            }
        }

        private void ck_pegar_horario_final_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_pegar_horario_final.Checked == true)
            {
                cb_hora_final.Enabled = false;
                cb_minutos_final.Enabled = false;
            }
            else
            {
                cb_hora_final.Enabled = true;
                cb_minutos_final.Enabled = true;
            }
        }

        private void bt_confirmar_correcao_Click(object sender, EventArgs e)
        {

            if (cb_vaga.Text == "" || txt_placa.Text == "" || cb_servico.Text == "")
            {
                MessageBox.Show("Por favor, preencha os campos Vaga, status da vaga, Placa do veículo, serviço prestado e horário inicial");
            }
            else
            {

                conexao c = new conexao();

                if (c.connect() == true)
                {

                    try
                    {
                        int selectedrowindex = dataGridControle.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGridControle.Rows[selectedrowindex];
                        String nota;

                         nota = Convert.ToString(selectedRow.Cells["id_nota_fiscal_uso"].Value);

                        
                        
                        String placa;
                        placa = txt_placa.Text.Trim();
                        String HorarioInicial;
                        string Date = DateTime.Now.ToString("yyyy-MM-dd");
                        String horarioFinal;
                        String servico = cb_servico.Text;
                        String vaga = cb_vaga.Text;
                        if (ck_pegar_horario_iniclal.Checked == true)
                        {
                            HorarioInicial = DateAndTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {

                            String hora1 = cb_hora_inicial.Text;
                            if (hora1 == "0" || hora1 == "1" || hora1 == "2" || hora1 == "3" || hora1 == "4" || hora1 == "5" || hora1 == "6" || hora1 == "7" || hora1 == "8" || hora1 == "9")
                            {
                                hora1 = "0" + hora1;
                            }

                            String minutos1 = cb_minuto_inicial.Text;
                            if (minutos1 == "0" || minutos1 == "1" || minutos1 == "2" || minutos1 == "3" || minutos1 == "4" || minutos1 == "5" || minutos1 == "6" || minutos1 == "7" || minutos1 == "8" || minutos1 == "9")
                            {
                                minutos1 = "0" + minutos1;
                            }
                            HorarioInicial = Date + " " + hora1 + ":" + minutos1;

                        }
                        if (ck_pegar_horario_final.Checked == true)
                        {
                            horarioFinal = DateAndTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        else
                        {

                            String hora1 = cb_hora_final.Text;
                            if (hora1 == "0" || hora1 == "1" || hora1 == "2" || hora1 == "3" || hora1 == "4" || hora1 == "5" || hora1 == "6" || hora1 == "7" || hora1 == "8" || hora1 == "9")
                            {
                                hora1 = "0" + hora1;
                            }
                            String minutos1 = cb_minutos_final.Text;
                            if (minutos1 == "0" || minutos1 == "1" || minutos1 == "2" || minutos1 == "3" || minutos1 == "4" || minutos1 == "5" || minutos1 == "6" || minutos1 == "7" || minutos1 == "8" || minutos1 == "9")
                            {
                                minutos1 = "0" + minutos1;
                            }

                            horarioFinal = Date + " " + hora1 + ":" + minutos1;

                        }

                        c.connect();
                        SqlDataAdapter dAdapter = new SqlDataAdapter();
                        DataSet dt = new DataSet();
                        
                        if(ck_uso.Checked==true)
                        {
                            c.command.CommandText = "exec usp_corrigir_parcialmente 1," + nota + ",'" + vaga + "', '" + placa + "', '" + servico + "', '" + HorarioInicial + "'";
                        } else
                        { 
                            c.command.CommandText = "exec usp_corrigir 1,"+ nota +",'" + vaga + "', '" + placa + "', '" + servico + "', '" + HorarioInicial + "','" +horarioFinal+"'";
                        }
                        c.command.ExecuteNonQuery();

                        c.fechaConexao();
                        MessageBox.Show("Dados alterados com sucesso!");
                        Carregar();
                        CarregarLivres();
                        inicial();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

        }

        private void ck_uso_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_uso.Checked==true)
            {
                cb_minutos_final.Enabled = false;
                cb_hora_final.Enabled = false;
                ck_pegar_horario_final.Enabled = false;

            }
            else
            {
                cb_minutos_final.Enabled = true;
                cb_hora_final.Enabled = true;
                ck_pegar_horario_final.Enabled = true;
            }
        }

        private void dataGridControle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void inicial()
        {
            panel_adicionar_update.Visible = false;
            panel_atualizar.Visible = false;
            btn_confirmar_novo.Visible = false;
            bt_cancelar_novo.Visible = false;
            btn_atualizar_vaga.Visible = false;
            btn_cancelar_status.Visible = false;
            bt_confirmar_correcao.Visible = false;
            bt_cancelar_correcao.Visible = false;


            btn_adicionar_uso.Visible = true;
            btn_corrigir.Visible = true;
            btn_update_status_vaga.Visible = true;
        }

        private void btn_corrigir_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Por favor, selecione a linha a ser alterada!");
        }
    }
}
