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
    public partial class FormConsultaVeiculo : Form
    {
        public string Placa { get; set; }

        public FormConsultaVeiculo()
        {
            InitializeComponent();
            Consultar();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Consultar ()
        {
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
