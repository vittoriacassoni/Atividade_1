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
        public IActionResult Details(string id)
        {
            try
            {
                EducationalDAO DAO = new EducationalDAO();
                List<EducationalViewModel> educationals = new List<EducationalViewModel>();
                educationals = DAO.ListEducationById(id);

                return Json(new
                {
                    success = true,
                    educationals
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
            EducationalViewModel person = new EducationalViewModel();

            ExperienceDAO DAO = new ExperienceDAO();

            return View("Form", person);
        }


        public IActionResult Salvar(EducationalViewModel educational, string Operacao)
        {
            try
            {
                ValidaDados(educational, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    return View("Form", educational);
                }
                else
                {
                    EducationalDAO dao = new EducationalDAO();
                    if (dao.GetRecordById(educational.CPF_EDUCATIONAL) == null)
                        dao.Add(educational);
                    else
                        dao.Update(educational);
                    return RedirectToAction("index");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                return View("Form", educational);
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