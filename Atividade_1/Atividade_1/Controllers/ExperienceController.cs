using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Atividade_1.Models;
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

        private void ValidaDados(ExperienceViewModel experience, string operacao)
        {
            ExperienceDAO dao = new ExperienceDAO();

            /* -------- REVISAR ESSA PARTE --------
            if (operacao == "I" && dao.GetRecordById(experience.CPF_EXPERIENCE) != null)
                ModelState.AddModelError("CPF", "CPF já cadastrado.");
            if (operacao == "A" && dao.GetRecordById(experience.CPF_EXPERIENCE) == null)
                ModelState.AddModelError("CPF", "CPF não cadastrado.");
            */

            if (string.IsNullOrEmpty(experience.COMPANY_NAME))
                ModelState.AddModelError("COMPANY_NAME", "Nome da empresa é obrigatorio.");
            if (string.IsNullOrEmpty(experience.PREVIOUS_POSITION))
                ModelState.AddModelError("PREVIOUS_POSITION", "Cargo anterior é obrigatorio.");
            if (experience.PREVIOUS_SALARY < 0)
                ModelState.AddModelError("PREVIOUS_SALARY", "Salario anterior não pode ser negativo");
        }
    }
}