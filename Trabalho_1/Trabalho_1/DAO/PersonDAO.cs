using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Trabalho_1.Models;

namespace Trabalho_1.DAO
{
    public class PersonDAO
    {
        /// <summary>
        /// Method to add
        /// </summary>
        /// <param name="model">Entity to add</param>
        public void Add(PersonViewModel model)
        {
            string sql = "insert into ODS_PERSONAL_DATA (CPF, HOME_ADDRESS, TELEPHONE, EMAIL_ADDRESS, PRETENSION_SALARY, INTENDED_POSITION) " +
                         "values (@CPF, @HOME_ADDRESS, @TELEPHONE, @EMAIL_ADDRESS, @PRETENSION_SALARY, @INTENDED_POSITION)";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to update
        /// </summary>
        /// <param name="model">Entity to update</param>
        public void Update(PersonViewModel model)
        {
            string sql = "update ODS_PERSONAL_DATA set HOME_ADDRESS = @HOME_ADDRESS, TELEPHONE = @TELEPHONE, " +
                         "EMAIL_ADDRESS = @EMAIL_ADDRESS, INTENDED_POSITION = @INTENDED_POSITION " +
                         "where CPF = @CPF";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        /// <summary>
        /// Method to delete
        /// </summary>
        /// <param name="id">Entity to delete</param>
        public void Delete(string id)
        {
            string sql = "delete ODS_PERSONAL_DATA where CPF = " + id;
            HelperDAO.ExecuteSQL(sql, null);
        }

        /// <summary>
        /// Method to return a person record
        /// </summary>
        /// <param name="id">Entity to to return a person record</param>
        /// <returns>model</returns>
        public PersonViewModel GetRecordById(string id)
        {
            string sql = "select * from ODS_PERSONAL_DATA where CPF = " + id;
            DataTable table = HelperDAO.ExecuteSQL(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return CreatePerson(table.Rows[0]);
        }

        /// <summary>
        /// Method to return the personal data table
        /// </summary>
        /// <returns>list</returns>
        public List<PersonViewModel> List()
        {
            List<PersonViewModel> list = new List<PersonViewModel>();
            string sql = "select * from ODS_PERSONAL_DATA";
            DataTable table = HelperDAO.ExecuteSQL(sql, null);

            foreach(DataRow dr in table.Rows)
            {
                list.Add(CreatePerson(dr));
            }
            return list;
        }


        public PersonViewModel CreatePerson(DataRow dr)
        {
            return new PersonViewModel()
            {
                CPF = dr["CPF"].ToString(),
                HOME_ADDRESS = dr["HOME_ADDRESS"].ToString(),
                TELEPHONE = dr["TELEPHONE"].ToString(),
                EMAIL_ADDRESS = dr["EMAIL_ADDRESS"].ToString(),
                PRETENSION_SALARY = Convert.ToDouble(dr["PRETENSION_SALARY"]),
                INTENDED_POSITION = dr["INTENDED_POSITION"].ToString()
            };
        }
    }
}