using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebEstacionamento.App_Code
{
    public class TableData
    {
        //private int permissao = Convert.ToInt32(HttpContext.Current.Session["user_perm"].ToString());

        private DataTable dt;
        private Conexao c = new Conexao();

        internal bool SetStatusToken(string id_token, bool status)
        {
            // altera o status do token de acordo com os parametros recebidos
            string comando_sql = "UPDATE tbl_token " +
                "SET status_token=@status " +
                "WHERE id_token=@token";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@token", SqlDbType.BigInt) {Value = id_token},
                new SqlParameter("@status", SqlDbType.Bit) {Value = status},
            };

            // retorna a quantidade
            bool sucesso = c.ManutencaoDB(comando_sql, paramsList);

            return sucesso;
        }

        internal bool SetStatusFunc(string id_func, bool status)
        {
            // altera o status do funcionario de acordo com os parametros recebidos
            string comando_sql = "UPDATE tbl_funcionario " +
                "SET status_func=@status " +
                "WHERE id_func=@func";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@func", SqlDbType.BigInt) {Value = id_func},
                new SqlParameter("@status", SqlDbType.Bit) {Value = status},
            };

            // retorna a quantidade
            bool sucesso = c.ManutencaoDB(comando_sql, paramsList);

            return sucesso;
        }

        internal bool SetStatusEst(string id_est, bool status)
        {
            // altera o status do estacionamento de acordo com os parametros recebidos
            string comando_sql = "UPDATE tbl_estacionamento " +
                "SET status_est=@status " +
                "WHERE id_estacionamento=@est";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@est", SqlDbType.BigInt) {Value = id_est},
                new SqlParameter("@status", SqlDbType.Bit) {Value = status},
            };

            // retorna a quantidade
            bool sucesso = c.ManutencaoDB(comando_sql, paramsList);

            return sucesso;
        }

        internal bool ApagarReserva(string id_reserva)
        {
            // altera o status do token de acordo com os parametros recebidos
            string comando_sql = "DELETE FROM tbl_reserva " +
                "WHERE id_reserva=@reserva";

            List<SqlParameter> paramsList = new List<SqlParameter>()
            {
                new SqlParameter("@reserva", SqlDbType.BigInt) {Value = id_reserva},
            };

            // retorna a quantidade
            bool sucesso = c.ManutencaoDB(comando_sql, paramsList);

            return sucesso;
        }
    }
}