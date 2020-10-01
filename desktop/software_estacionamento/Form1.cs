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
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();
        }

        private void form_login_Load(object sender, EventArgs e)
        {

        }

        private void btn_acessar_Click(object sender, EventArgs e)
        {
                conexao c = new conexao();
                
                if (c.connect() == true)
                {

                

                try
                    {

                        SqlDataAdapter dAdapter = new SqlDataAdapter();
                        DataSet dt = new DataSet();
                        DataSet perm = new DataSet();
                        c.connect();

                        String login, senha;
                        login = txt_user.Text.Trim();
                        senha = txt_senha.Text.Trim();
                        

                        String sql;
                        sql = "select count(*) as qtd from tbl_funcionario_est where " + "id_func=@login and senha_func=@senha and status_func=1";
                        c.command.CommandText = sql;
                        c.command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                        c.command.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                        dAdapter.SelectCommand = c.command;
                        dAdapter.Fill(dt);


                        if ((int)dt.Tables[0].DefaultView[0].Row["qtd"] == 1)
                        {
                            String sql2;
                            sql2 = "select count(*) as permissao from tbl_funcionario_est where id_func=" + login +  "and permissao=0";
                            c.command.CommandText = sql2;
                            dAdapter.SelectCommand = c.command;
                            dAdapter.Fill(perm);

                            if ((int)perm.Tables[0].DefaultView[0].Row["permissao"] == 1)
                            {
                                    Controle_Admin frm = new Controle_Admin();

                                    frm.Show();
                                    this.Hide();
                            } 
                            else
                            { 
                                    form_func frm = new form_func();

                                    frm.Show();
                                    this.Hide();
                            }
                                
                        }
                        else
                        {
                            MessageBox.Show("Usuário e/ou senha incorretos");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha no login" + ex);
                    }
                }
        }




        

        
    }
}
