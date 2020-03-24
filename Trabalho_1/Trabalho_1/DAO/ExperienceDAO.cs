using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Trabalho_1.Models;

namespace Trabalho_1.DAO
{
    public class ExperienceDAO
    {
        private SqlParameter[] CreateParameters(ExperienceViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("PREVIOUS_COMPANY_NAME", model.COMPANY_NAME);
            parametros[1] = new SqlParameter("PREVIOUS_POSITION", model.PREVIOUS_POSITION);
            parametros[2] = new SqlParameter("PREVIOUS_SALARY", model.PREVIOUS_SALARY);
            parametros[3] = new SqlParameter("CPF", model.CPF_EXPERIENCE);
            return parametros;
        }
        /// <summary>
        /// Method to add
        /// </summary>
        /// <param name="model">Entity to add</param>
        public void Add(ExperienceViewModel model)
        {
            string sql = "insert into ODS_PROFESSIONAL_EXPERIENCE (PREVIOUS_COMPANY_NAME, " +
                         "PREVIOUS_POSITION, PREVIOUS_SALARY, CPF) " +
                         "values (@PREVIOUS_COMPANY_NAME, @PREVIOUS_POSITION, @PREVIOUS_SALARY, @CPF_EXPERIENCE)";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to update
        /// </summary>
        /// <param name="model">Entity to update</param>
        public void Update(ExperienceViewModel model)
        {
            string sql = "update ODS_PROFESSIONAL_EXPERIENCE set PREVIOUS_COMPANY_NAME = @PREVIOUS_COMPANY_NAME," +
                         "PREVIOUS_POSITION = @PREVIOUS_POSITION, PREVIOUS_SALARY = @PREVIOUS_SALARY " +
                         "where CPF = @CPF_EXPERIENCE";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to delete
        /// </summary>
        /// <param name="model">Entity to delete</param>
        public void Delete(string id)
        {
            string sql = "delete ODS_PROFESSIONAL_EXPERIENCE where CPF = " + id;
            HelperDAO.ExecuteSQL(sql, null);
        }

        /// <summary>
        /// Method to return an experience record
        /// </summary>
        /// <param name="id">Entity to return an experience record</param>
        /// <returns></returns>
        public ExperienceViewModel GetRecordById(string id)
        {
            string sql = "select * from ODS_PROFESSIONAL_EXPERIENCE where CPF = " + id;
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return AddExperience(table.Rows[0]);
        }

        /// <summary>
        /// Method to return the experience table
        /// </summary>
        /// <returns></returns>
        public List<ExperienceViewModel> List()
        {
            List<ExperienceViewModel> list = new List<ExperienceViewModel>();
            string sql = "select * from ODS_PROFESSIONAL_EXPERIENCE";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            foreach (DataRow dr in table.Rows)
            {
                list.Add(AddExperience(dr));
            }
            return list;
        }

        public ExperienceViewModel AddExperience(DataRow dr)
        {
            return new ExperienceViewModel()
            {
                COMPANY_NAME = dr["COMPANY_NAME"].ToString(),
                PREVIOUS_POSITION = dr["PREVIOUS_POSITION"].ToString(),
                PREVIOUS_SALARY =Convert.ToDouble(dr["PREVIOUS_SALARY"]),
                CPF_EXPERIENCE = dr["CPF"].ToString()
            };
        }
    }
}