using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebEstacionamento.App_Code
{
    public class Dashboard
    {
        private string usuario = HttpContext.Current.Session["cpfcnpj"].ToString();
        private int permissao = Convert.ToInt32(HttpContext.Current.Session["user_perm"].ToString());

        private DataTable dt;
        private Conexao c = new Conexao();

        public Dashboard()
        {
        }

        public string Reservas
        {
            get
            {
                if (permissao == 4)
                {
                    // para o usuario logado
                    // lista todas as reservas ativas (pendentes/em aberto) que ele possui
                    string comando_sql = "SELECT * FROM tbl_reservas " +
                        "WHERE (datediff(hour, timestamp_final_reserva, getdate()) <= 0) " +
                        "AND tbl_usuario_id_CPF_usuario=@usuario";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@usuario", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdReservas = Convert.ToString(dt.Rows.Count);

                    return qtdReservas;
                }
                else if (permissao == 2)
                {
                    // para a empresa logada
                    // lista todas as reservas ativas (pendentes/em aberto) para todos os estacionamentos que ela possui
                    string comando_sql = "SELECT * FROM tbl_reservas " +
                        "WHERE (datediff(hour, timestamp_final_reserva, getdate()) <= 0) " +
                        "AND tbl_vaga_id_vaga " +
                        "IN (SELECT tbl_vaga_id_vaga " +
                        "FROM tbl_vaga " +
                        "WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT id_estacionamento " +
                        "FROM tbl_estacionamento WHERE tbl_empresa_id_cnpj_empresa=@empresa))";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@empresa", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdReservas = Convert.ToString(dt.Rows.Count);

                    return qtdReservas;
                }
                else if (permissao == 3)
                {
                    // para o funcionario logado
                    // lista todas as reservas ativas (pendentes/em aberto) do estacionamento onde ele trabalha
                    string comando_sql = "SELECT * FROM tbl_reservas " +
                        "WHERE (datediff(hour, timestamp_final_reserva, getdate()) <= 0) " +
                        "AND tbl_vaga_id_vaga " +
                        "IN (SELECT tbl_vaga_id_vaga " + 
                        "FROM tbl_vaga " +
                        "WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT tbl_estacionamento_id_estacionamento " +
                        "FROM tbl_funcionario_est WHERE id_func=@func))";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@func", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdReservas = Convert.ToString(dt.Rows.Count);

                    return qtdReservas;
                }
                else
                {
                    // para o administrador master (permissao = 1)
                    // lista todas as reservas ativas (pendentes/em aberto)
                    // de todos os usuarios para qualquer estacionamento do sistema
                    string comando_sql = "SELECT * FROM tbl_reservas " +
                        "WHERE (datediff(hour, timestamp_final_reserva, getdate()) <= 0)";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdReservas = Convert.ToString(dt.Rows.Count);

                    return qtdReservas;
                }
            }
        }
        public string Vagas
        {
            get
            {
                if (permissao == 2)
                {
                    // para a empresa logada
                    // lista todas as vagas de todos os estacionamentos que ela possui
                    string comando_sql = "SELECT * FROM tbl_vaga " +
                        "WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT id_estacionamento " +
                        "FROM tbl_estacionamento WHERE tbl_empresa_id_cnpj_empresa=@empresa)";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@empresa", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdVagas = Convert.ToString(dt.Rows.Count);

                    return qtdVagas;
                }
                else if (permissao == 3)
                {
                    // para o funcionario logado
                    // lista todas as vagas do estacionamento onde ele trabalha
                    string comando_sql = "SELECT * FROM tbl_vaga " +
                        "WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT tbl_estacionamento_id_estacionamento " +
                        "FROM tbl_funcionario_est WHERE id_func=@func)";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@func", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdVagas = Convert.ToString(dt.Rows.Count);

                    return qtdVagas;
                }
                else if (permissao == 1)
                {
                    // para o administrador master
                    // lista todas as vagas de todos os estacionamentos de todas as empresas do sistema
                    string comando_sql = "SELECT * FROM tbl_vaga";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdVagas = Convert.ToString(dt.Rows.Count);

                    return qtdVagas;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Veiculos
        {
            get
            {
                if (permissao == 4)
                {
                    // para o usuario logado
                    // lista todos os veiculos que ele possui
                    string comando_sql = "SELECT * FROM tbl_user_veiculo " +
                        "WHERE id_CPF_usuario=@usuario";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@usuario", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdVeiculos = Convert.ToString(dt.Rows.Count);
                
                    return qtdVeiculos;
                }
                else if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os veiculos de todos os usuarios do sistema
                    string comando_sql = "SELECT * FROM tbl_veiculos";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdVeiculos = Convert.ToString(dt.Rows.Count);

                    return qtdVeiculos;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Estacionamentos
        {
            get
            {
                if (permissao == 2)
                {
                    // para a empresa logada
                    // lista todos os estacionamentos que ela possui
                    string comando_sql = "SELECT * FROM tbl_estacionamento " +
                        "WHERE tbl_empresa_id_cnpj_empresa=@empresa";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@empresa", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdEstacionamentos = Convert.ToString(dt.Rows.Count);

                    return qtdEstacionamentos;
                }
                else if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os estacionamentos de todas as empresas do sistema
                    string comando_sql = "SELECT * FROM tbl_estacionamento";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdEstacionamentos = Convert.ToString(dt.Rows.Count);

                    return qtdEstacionamentos;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Funcionarios
        {
            get
            {
                if (permissao == 2)
                {
                    // para a empresa logada
                    // retorna todos os funcionarios de todos os estacionamentos que ela possui
                    string comando_sql = "SELECT * FROM tbl_funcionario_est " +
                        "WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT id_estacionamento " +
                        "FROM tbl_estacionamento WHERE tbl_empresa_id_cnpj_empresa=@empresa)";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@empresa", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdFuncionarios = Convert.ToString(dt.Rows.Count);

                    return qtdFuncionarios;
                }
                else if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os funcionarios de todas as empresas do sistema
                    string comando_sql = "SELECT * FROM tbl_funcionario_est";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdFuncionarios = Convert.ToString(dt.Rows.Count);

                    return qtdFuncionarios;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Equipamentos
        {
            get
            {
                if (permissao == 2)
                {
                    // para a empresa logada
                    // retorna todos os equipamentos de todas as vagas de todos os estacionamentos que ela possui
                    string comando_sql = "SELECT * FROM tbl_equipamento " +
                        "WHERE id_equipamento " +
                        "IN (SELECT tbl_equipamento_id_equipamento " +
                        "FROM tbl_vaga WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT id_estacionamento " +
                        "FROM tbl_estacionamento WHERE tbl_empresa_id_cnpj_empresa=@empresa))";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@empresa", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdEquipamentos = Convert.ToString(dt.Rows.Count);

                    return qtdEquipamentos;
                }
                else if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os equipamentos de todas vagas de todas as empresas do sistema
                    string comando_sql = "SELECT * FROM tbl_equipamento";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdEquipamentos = Convert.ToString(dt.Rows.Count);

                    return qtdEquipamentos;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Servicos
        {
            get
            {
                if (permissao == 2)
                {
                    // para a empresa logada
                    // lista todos os servicos de todos os estacionamentos que ela possui
                    string comando_sql = "SELECT * FROM tbl_servico " +
                        "WHERE tbl_estacionamento_id_estacionamento " +
                        "IN (SELECT id_estacionamento " +
                        "FROM tbl_estacionamento WHERE tbl_empresa_id_cnpj_empresa=@empresa)";

                    List<SqlParameter> paramsList = new List<SqlParameter>()
                    {
                        new SqlParameter("@empresa", SqlDbType.VarChar) {Value = usuario},
                    };

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdServicos = Convert.ToString(dt.Rows.Count);

                    return qtdServicos;
                }
                else if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os servicos de todas as empresas do sistema
                    string comando_sql = "SELECT * FROM tbl_servico";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdServicos = Convert.ToString(dt.Rows.Count);

                    return qtdServicos;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Usuarios
        {
            get
            {
                if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os usuarios do sistema
                    string comando_sql = "SELECT * FROM tbl_usuario";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdUsuarios = Convert.ToString(dt.Rows.Count);

                    return qtdUsuarios;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Empresas
        {
            get
            {
                if (permissao == 1)
                {
                    // para o administrador master
                    // lista todas as empresas do sistema
                    string comando_sql = "SELECT * FROM tbl_empresa";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdEmpresas = Convert.ToString(dt.Rows.Count);

                    return qtdEmpresas;
                }
                else
                {
                    return "N/A";
                }
            }
        }
        public string Tokens
        {
            get
            {
                if (permissao == 1)
                {
                    // para o administrador master
                    // lista todos os tokens do sistema
                    string comando_sql = "SELECT * FROM tbl_token";

                    List<SqlParameter> paramsList = new List<SqlParameter>();

                    dt = c.ExecutarSQL(comando_sql, paramsList);

                    // retorna a quantidade
                    string qtdTokens = Convert.ToString(dt.Rows.Count);

                    return qtdTokens;
                }
                else
                {
                    return "N/A";
                }
            }
        }
    }
}