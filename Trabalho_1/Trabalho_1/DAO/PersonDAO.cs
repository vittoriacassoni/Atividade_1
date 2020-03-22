using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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
                         "values (@CPF, @ADDRESS, @TELEPHONE, @EMAIL_ADDRESS, @PRETENSION_SALARY, @INTENDED_POSITION)";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        public void Update(PersonViewModel model)
        {
            string sql = "update ODS_PERSONAL_DATA set [ADDRESS] = @ADDRESS, TELEPHONE = @TELEPHONE, " +
                         "EMAIL_ADDRESS = @EMAIL_ADDRESS, INTENDED_POSITION = @INTENDED_POSITION " +
                         "where CPF = @CPF";
            HelperDAO.ExecuteSQL(sql, CreateParameters(model));
        }

        public void Delete(int id)
        {
            string sql = "delete ODS_PERSONAL where CPF = " + id;
            HelperDAO.ExecuteSQL(sql, null);
        }

        public PersonViewModel GetRecordById(int id)
        {
            string sql = "select * from ODS_PERSONAL_DATA where CPF = " + id;
            DataTable table = HelperDAO.ExecuteSQL(sql, null);

            if (table.Rows.Count == 0)
                return null;
            else
                return CreatePerson(table.Rows[0]);
        }

        public List<PersonViewModel> List()
        {
            List<PersonViewModel> list = new List<PersonViewModel>();
            string sql = "select * from ODS_PERSONAL_DATA";
            DataTable table = HelperDAO.ExecuteSQL(sql, null);

            foreach(DataRow dr in table.Rows)
            {
                List.Add(CreatePerson(dr));
            }
            return list;
        }

        public PersonViewModel CreatePerson(DataRow dr)
        {
            return new PersonViewModel()
            {
                CPF = dr["CPF"].ToString(),
                Address = dr["HOME_ADDRESS"].ToString(),
                Telephone = dr["TELEPHONE"].ToString(),
                EmailAddress = dr["EMAIL_ADDRESS"].ToString(),
                PretensionSalary = Convert.ToDouble(dr["PRETENSION_SALARY"]).ToString(),
                IntendedPosition = dr["INTENDED_POSITION"].ToString()
            };
        }
    }
}