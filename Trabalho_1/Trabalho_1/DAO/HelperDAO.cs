using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Trabalho_1.DAO
{
    public static class HelperDAO
    {
        public static void ExecuteSQL(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConnectionDB.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
        public static DataTable ExecuteSelect(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConnectionDB.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabelaTemp = new DataTable();
                    adapter.Fill(tabelaTemp);
                    conexao.Close();
                    return tabelaTemp;
                }
            }
        }

    }

}