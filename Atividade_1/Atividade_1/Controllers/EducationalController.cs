using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Atividade_1.Models;
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

        private void ValidaDados(EducationalViewModel education, string operacao)
        {
            EducationalDAO dao = new EducationalDAO();

            /* -------- REVISAR ESSA PARTE --------
            if (operacao == "I" && dao.GetRecordById(education.CPF_EDUCATIONAL) != null)
                ModelState.AddModelError("CPF", "CPF já cadastrado.");
            if (operacao == "A" && dao.GetRecordById(education.CPF_EDUCATIONAL) == null)
                ModelState.AddModelError("CPF", "CPF não cadastrado.");
            */

            if (education.ID_COURSE < 0)
                ModelState.AddModelError("ID_COURSE", "Codigo do curso não pode ser negativo.");
            if (education.BEGINNING_DATE > education.CONCLUSION_DATE)
            {
                ModelState.AddModelError("BEGINNING_DATE", "Data inicial está depois da final.");
                ModelState.AddModelError("CONCLUSION_DATE", "Data final está antes da inicial.");
            }
            if (string.IsNullOrEmpty(education.SCHOOL_NAME))
                ModelState.AddModelError("SCHOOL_NAME", "Nome da escola é obrigatorio.");
            if (string.IsNullOrEmpty(education.COURSE_NAME))
                ModelState.AddModelError("COURSE_NAME", "Nome do curso é obrigatorio.");
        }
    }
}