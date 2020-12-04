using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WebEstacionamento.App_Code
{
    public class Conexao
    {
        private string usuarioBD = "";
        private string senhaBD = "";

        private SqlConnection conexao = new SqlConnection();

        private SqlConnection Conectar()
        {
            try
            {
                string strConexao = $"Initial Catalog=bd_estacionamentos; Persist Security Info=True; User ID={usuarioBD}; Password={senhaBD}; Data Source=" + Environment.MachineName;
                conexao.ConnectionString = strConexao;
                conexao.Open();
                return conexao;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao conectar no BD: {e}");
                Desconectar();
                return null;
            }
        }

        private void Desconectar()
        {
            try
            {
                if ((conexao.State == ConnectionState.Open))
                {
                    conexao.Close();
                    conexao.Dispose();
                    conexao = null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao desconectar no BD: {e}");
            }
        }

        public DataTable ExecutarSQL(string comando_sql, List<SqlParameter> params_sql)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(comando_sql, Conectar()))
                {
                    comando.Parameters.AddRange(params_sql.ToArray());
                    SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    conexao.Dispose();
                    return dt;
                }
                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ExecutarSQL: {e}");
                return null;
            }
        }

        public bool ManutencaoDB(string comando_sql, List<SqlParameter> params_sql)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(comando_sql, Conectar()))
                {
                    comando.Parameters.AddRange(params_sql.ToArray());
                    comando.ExecuteScalar();
                    conexao.Dispose();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ManutencaoDB: {e}");
                return false;
            }
        }
    }
}