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
                educationals = DAO.ListEducationByCPF(id);

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
                    if (Operacao == "A")
                        dao.Update(educational);
                    else
                        dao.Add(educational);
                    return RedirectToAction("index", "Person");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                return View("Form", educational);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Operacao = "A";
            EducationalViewModel educational = new EducationalViewModel();

            EducationalDAO DAO = new EducationalDAO();

            educational = DAO.GetRecordByID(id);

            if (educational == null)
                return RedirectToAction("Listagem", "Person");
            return View("Form", educational);
        }

        private void ValidaDados(EducationalViewModel education, string operacao)
        {
            EducationalDAO dao = new EducationalDAO();
            PersonDAO perDAO = new PersonDAO();

            if (education.BEGINNING_DATE > education.CONCLUSION_DATE)
            {
                ModelState.AddModelError("BEGINNING_DATE", "Data inicial está depois da final.");
                ModelState.AddModelError("CONCLUSION_DATE", "Data final está antes da inicial.");
            }
            if (string.IsNullOrEmpty(education.SCHOOL_NAME))
                ModelState.AddModelError("SCHOOL_NAME", "Nome da escola é obrigatorio.");
            if (string.IsNullOrEmpty(education.COURSE_NAME))
                ModelState.AddModelError("COURSE_NAME", "Nome do curso é obrigatorio.");
            if (perDAO.GetRecordByCPF(education.CPF_EDUCATIONAL) == null) //procura o cpf na tabela person pra ver se aquele cpf é valido
                ModelState.AddModelError("CPF", "CPF invalido");
            if (operacao == "I" && dao.ListEducationByCPF(education.CPF_EDUCATIONAL).Count >= 5)
                ModelState.AddModelError("CPF", "O numero limite de cursos com esse CPF ja foi atingido.");
        }
    }
}