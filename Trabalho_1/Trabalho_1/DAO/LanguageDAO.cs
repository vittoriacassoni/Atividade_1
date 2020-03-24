using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Trabalho_1.Models;

namespace Trabalho_1.DAO
{
    public class LanguageDAO
    {
        /// <summary>
        /// Method to add
        /// </summary>
        /// <param name="model">Entity to add</param>
        public void Add(LanguageViewModel model)
        {
            string sql = "insert into ODS_LANGUAGE(LANGUAGE_NAME, SCHOOL_LANGUAGE_NAME, ID_COURSE) " +
                "values (@LANGUAGE_NAME, @SCHOOL_LANGUAGE_NAME, @ID_COURSE)";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to update
        /// </summary>
        /// <param name="model">Entity to update</param>
        public void Update(LanguageViewModel model)
        {
            string sql = "update ODS_LANGUAGE set LANGUAGE_NAME = @LANGUAGE_NAME, " +
                         "SCHOOL_LANGUAGE_NAME = @SCHOOL_LANGUAGE_NAME where " +
                         "ID_COURSE = @ID_COURSE";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to delete
        /// </summary>
        /// <param name="id">Entity to delete</param>
        public void Delete(string id)
        {
            string sql = "delete ODS_LANGUAGE where ID_COURSE = " + id;
            HelperDAO.ExecuteSQL(sql, null);
        }

        /// <summary>
        /// Method to return a language record
        /// </summary>
        /// <param name="id">Entity to return a language record</param>
        /// <returns>model</returns>
        public LanguageViewModel GetRecordById(string id)
        {
            string sql = "select * from ODS_LANGUAGE where ID_COURSE = " + id;
            DataTable table = HelperDAO.ExecuteSQL(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return AddLanguage(table.Rows[0]);
        }

        /// <summary>
        /// Method to return the language table
        /// </summary>
        /// <returns>list</returns>
        public List<LanguageViewModel> List()
        {
            List<LanguageViewModel> list = new List<LanguageViewModel>();
            string sql = "select * from ODS_LANGUAGE";
            DataTable table = HelperDAO.ExecuteSQL(sql, null);

            foreach(DataRow dr in table.Rows)
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
                SCHOOL_LANGUAGE_NAME = dr["SCHOOL_LANGUAGE_COURSE"].ToString(),
                ID_COURSE = Convert.ToInt32(dr["ID_COURSE"])
            };
        }
    }
}