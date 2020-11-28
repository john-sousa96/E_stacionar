using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

public class conexao
{
    public conexao()
    {

    }

    public SqlConnection con;
    public SqlCommand command;

    public Boolean connect()
    {
        try
        {
            String strConexao;
            strConexao = "Database=bd_estacionamentos;" +
                        "Server = localhost; user id = sa;  password = abc1234";
            con = new SqlConnection(strConexao);
            con.Open();
            command = new SqlCommand();
            command.Connection = con;
            return true;

        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("falha" + e);
            fechaConexao();
            return false;
        }


    }
    public void fechaConexao()
    {
        con.Close();
        command = null;
        con = null;
    }
}
