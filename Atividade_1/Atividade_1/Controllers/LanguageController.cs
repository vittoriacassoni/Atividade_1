using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            try
            {
                LanguageDAO language = new LanguageDAO();
                language.GetRecordById(id);
                return View(language);
            }
            catch (Exception erro)
            {
                throw;
            }
        }
    }
}