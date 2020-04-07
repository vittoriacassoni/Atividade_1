using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Atividade_1.Models;
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

        private void ValidaDados(LanguageViewModel language, string operacao)
        {
            LanguageDAO dao = new LanguageDAO();
            if (string.IsNullOrEmpty(language.LANGUAGE_NAME))
                ModelState.AddModelError("LANGUAGE_NAME", "Nome da lingua é obrigatorio.");
            if (string.IsNullOrEmpty(language.SCHOOL_LANGUAGE_NAME))
                ModelState.AddModelError("SCHOOL_LANGUAGE_NAME", "Nome da escola de lingua é obrigatorio."); //precisa?
            if (language.ID_COURSE < 0)
                ModelState.AddModelError("ID_COURSE", "Código precisa ser positivo.");
        }
    }
}