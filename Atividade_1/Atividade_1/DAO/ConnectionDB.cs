using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.DAO
{
    public class ConnectionDB
    {
        public static SqlConnection GetConexao()
        {
            string strCon = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=DBRESUME;user id=sa; password=123456";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
