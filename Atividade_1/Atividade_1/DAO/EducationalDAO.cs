using Atividade_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.DAO
{
    public class EducationalDAO
    {
        /// <summary>
        /// Creates parameters to avoid SQL injection
        /// </summary>
        /// <param name="model">Entity</param>
        /// <returns>Parameter vector</returns>
        private SqlParameter[] CreateParameters(EducationalViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("BEGINNING_DATE", model.BEGINNING_DATE);
            parametros[1] = new SqlParameter("CONCLUSION_DATE", model.CONCLUSION_DATE);
            parametros[2] = new SqlParameter("SCHOOL_NAME", model.SCHOOL_NAME);
            parametros[3] = new SqlParameter("COURSE_NAME", model.COURSE_NAME);
            parametros[4] = new SqlParameter("CPF_EDUCATIONAL", model.CPF_EDUCATIONAL);
            parametros[5] = new SqlParameter("ID", model.ID);
            return parametros;
        }

        /// <summary>
        /// Method to add
        /// </summary>
        /// <param name="model">Entity to add</param>
        public void Add(EducationalViewModel model)
        {
            string sql = "insert into ODS_EDUCATIONAL_BACKGROUND(BEGINNING_DATE, " +
                "CONCLUSION_DATE, SCHOOL_NAME, COURSE_NAME, CPF) values " +
                "(@BEGINNING_DATE, @CONCLUSION_DATE, @SCHOOL_NAME, @COURSE_NAME, " +
                "@CPF_EDUCATIONAL)";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to update
        /// </summary>
        /// <param name="model">Entity to update</param>
        public void Update(EducationalViewModel model)
        {
            string sql = "update ODS_EDUCATIONAL_BACKGROUND set " +
                         "BEGINNING_DATE = @BEGINNING_DATE, CONCLUSION_DATE = @CONCLUSION_DATE, " +
                         "SCHOOL_NAME = @SCHOOL_NAME, COURSE_NAME = @COURSE_NAME, CPF = @CPF_EDUCATIONAL " +
                         "where ID = @ID";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to Delete
        /// </summary>
        /// <param name="id">Entity to Delete</param>
        public void Delete(int id)
        {
            string sql = "delete ODS_EDUCATIONAL_BACKGROUND where ID = " + id;
            HelperDAO.ExecuteSQL(sql, null);
        }

        /// <summary>
        /// Method to return an educational record
        /// </summary>
        /// <param name="id">Entity to return an educational record</param>
        /// <returns>model</returns>
        public EducationalViewModel GetRecordByCPF(string id)
        {
            string sql = $"select * from ODS_EDUCATIONAL_BACKGROUND where CPF = '{id}'";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return AddEducational(table.Rows[0]);
        }

        public EducationalViewModel GetRecordByID(int id)
        {
            string sql = $"select * from ODS_EDUCATIONAL_BACKGROUND where ID = '{id}'";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return AddEducational(table.Rows[0]);
        }

        /// <summary>
        /// Method to return an list of educational records
        /// </summary>
        /// <param name="id">Entity to return an list of educational records</param>
        /// <returns>model</returns>
        public List<EducationalViewModel> ListEducationByCPF(string id)
        {
            string sql = $"select * from ODS_EDUCATIONAL_BACKGROUND where CPF = '{id}'";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            List<EducationalViewModel> list = new List<EducationalViewModel>();
            foreach (DataRow dr in table.Rows)
            {
                list.Add(AddEducational(dr));
            }
            return list;
        }
        /// <summary>
        /// Method to return the educational table
        /// </summary>
        /// <returns>list</returns>
        public List<EducationalViewModel> List()
        {
            List<EducationalViewModel> list = new List<EducationalViewModel>();
            string sql = "select * from ODS_EDUCATIONAL_BACKGROUND";
            DataTable table = HelperDAO.ExecuteSelect(sql, null);

            foreach (DataRow dr in table.Rows)
            {
                list.Add(AddEducational(dr));
            }
            return list;
        }

        public EducationalViewModel AddEducational(DataRow dr)
        {
            return new EducationalViewModel()
            {
                BEGINNING_DATE = Convert.ToDateTime(dr["BEGINNING_DATE"]),
                CONCLUSION_DATE = Convert.ToDateTime(dr["CONCLUSION_DATE"]),
                SCHOOL_NAME = dr["SCHOOL_NAME"].ToString(),
                COURSE_NAME = dr["COURSE_NAME"].ToString(),
                CPF_EDUCATIONAL = dr["CPF"].ToString(),
                ID = Convert.ToInt32(dr["ID"])
            };
        }
    }
}
