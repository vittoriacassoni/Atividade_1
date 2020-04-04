using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Controllers
{
    public class EducationalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            try
            {
                EducationalDAO education = new EducationalDAO();
                education.GetRecordById(id);
                return View(education);
            }
            catch (Exception erro)
            {
                throw;
            }
        }
    }
}