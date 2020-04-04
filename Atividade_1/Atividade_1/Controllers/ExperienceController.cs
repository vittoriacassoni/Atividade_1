using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            try
            {
                ExperienceDAO experience = new ExperienceDAO();
                experience.GetRecordById(id);
                return View(experience);
            }
            catch (Exception erro)
            {
                throw;
            }
        }
    }
}