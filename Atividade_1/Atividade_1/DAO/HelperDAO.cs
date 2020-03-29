using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.DAO
{
    public static class HelperDAO
    {
        /// <summary>
        /// Execute SQL commands
        /// </summary>
        /// <param name="sql">SQL command</param>
        /// <param name="parameters">Parameter</param>
        public static void ExecuteSQL(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = ConnectionDB.GetConexao())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        /// <summary>
        /// Executes a select statement and turns it into a DataTable
        /// </summary>
        /// <param name="sql">SQL command</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public static DataTable ExecuteSelect(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = ConnectionDB.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
                {
                    if (parameters != null)
                        adapter.SelectCommand.Parameters.AddRange(parameters);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    connection.Close();

                    return table;
                }
            }
        }
    }
}
