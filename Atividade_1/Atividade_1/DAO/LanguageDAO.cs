using Atividade_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.DAO
{
    public class LanguageDAO
    {
        /// <summary>
        /// Creates parameters to avoid SQL injection
        /// </summary>
        /// <param name="model">Entity</param>
        /// <returns>Parameter vector</returns>
        private SqlParameter[] CreateParameters(LanguageViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("LANGUAGE_NAME", model.LANGUAGE_NAME);
            parametros[1] = new SqlParameter("SCHOOL_LANGUAGE_NAME", model.SCHOOL_LANGUAGE_NAME);
            parametros[2] = new SqlParameter("CPF", model.CPF);
            parametros[3] = new SqlParameter("ID", model.ID);
            return parametros;
        }

        /// <summary>
        /// Method to add
        /// </summary>
        /// <param name="model">Entity to add</param>
        public void Add(LanguageViewModel model)
        {
            string sql = "insert into ODS_LANGUAGE(LANGUAGE_NAME, SCHOOL_LANGUAGE_NAME, CPF) " +
                "values (@LANGUAGE_NAME, @SCHOOL_LANGUAGE_NAME, @CPF)";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to update
        /// </summary>
        /// <param name="model">Entity to update</param>
        public void Update(LanguageViewModel model)
        {
            string sql = "update ODS_LANGUAGE set LANGUAGE_NAME = @LANGUAGE_NAME, CPF = @CPF, " +
                         "SCHOOL_LANGUAGE_NAME = @SCHOOL_LANGUAGE_NAME where " +
                         "ID = @ID";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to delete
        /// </summary>
        /// <param name="id">Entity to delete</param>
        public void Delete(int id)
        {
            string sql = "delete ODS_LANGUAGE where ID = " + id;
            HelperDAO.ExecuteSQL(sql, null);
        }

        /// <summary>
        /// Method to return a language record
        /// </summary>
        /// <param name="cpf">Entity to return a language record</param>
        /// <returns>model</returns>
        public LanguageViewModel GetRecordByCPF(string cpf)
        {
            string sql = $"select * from ODS_LANGUAGE where CPF = '{cpf}'";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return AddLanguage(table.Rows[0]);
        }

        public LanguageViewModel GetRecordByID(int id)
        {
            string sql = $"select * from ODS_LANGUAGE where ID = {id}";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return AddLanguage(table.Rows[0]);
        }

        /// <summary>
        /// Method to return a list of language records
        /// </summary>
        /// <param name="id">Entity to return an list of language records</param>
        /// <returns>model</returns>
        public List<LanguageViewModel> ListLanguageByCPF(string id)
        {
            string sql = $"select * from ODS_LANGUAGE where CPF = '{id}'";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            List<LanguageViewModel> list = new List<LanguageViewModel>();
            foreach (DataRow dr in table.Rows)
            {
                list.Add(AddLanguage(dr));
            }
            return list;
        }

        /// <summary>
        /// Method to return the language table
        /// </summary>
        /// <returns>list</returns>
        public List<LanguageViewModel> List()
        {
            List<LanguageViewModel> list = new List<LanguageViewModel>();
            string sql = "select * from ODS_LANGUAGE";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            foreach (DataRow dr in table.Rows)
            {
                list.Add(AddLanguage(dr));
            }
            return list;
        }

        public LanguageViewModel AddLanguage(DataRow dr)
        {
            return new LanguageViewModel()
            {
                LANGUAGE_NAME = dr["LANGUAGE_NAME"].ToString(),
                SCHOOL_LANGUAGE_NAME = dr["SCHOOL_LANGUAGE_NAME"].ToString(),
                CPF = dr["CPF"].ToString(),
                ID = Convert.ToInt32(dr["ID"])
            };
        }
    }
}
