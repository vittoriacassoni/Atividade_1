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
        public IActionResult Details(string id)
        {
            try
            {
                ExperienceDAO DAO = new ExperienceDAO();
                List<ExperienceViewModel> experiences = new List<ExperienceViewModel>();
                experiences = DAO.ListExperienceById(id);

                return Json(new
                {
                    success = true,
                    experiences
                }, new Newtonsoft.Json.JsonSerializerSettings());
            }
            catch (Exception erro)
            {
                throw;
            }
        }

        public IActionResult Create()
        {
            ViewBag.Operacao = "I";
            ExperienceViewModel person = new ExperienceViewModel();

            ExperienceDAO DAO = new ExperienceDAO();

            return View("Form", person);
        }


        public IActionResult Salvar(ExperienceViewModel experience, string Operacao)
        {
            try
            {
                ValidaDados(experience, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    return View("Form", experience);
                }
                else
                {
                    ExperienceDAO dao = new ExperienceDAO();
                    if (dao.GetRecordById(experience.CPF_EXPERIENCE) == null)
                        dao.Add(experience);
                    else
                        dao.Update(experience);
                    return RedirectToAction("index");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                return View("Form", experience);
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