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
        public IActionResult Details(string id)
        {
            try
            {
                LanguageDAO DAO = new LanguageDAO();
                List<LanguageViewModel> languages = new List<LanguageViewModel>();
                languages = DAO.ListLanguageByCPF(id);
                return View(languages);
            }
            catch (Exception erro)
            {
                throw;
            }
        }

        public IActionResult Create()
        {
            ViewBag.Operacao = "I";
            LanguageViewModel person = new LanguageViewModel();

            LanguageDAO DAO = new LanguageDAO();

            return View("Form", person);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Operacao = "A";
            LanguageViewModel language = new LanguageViewModel();

            LanguageDAO DAO = new LanguageDAO();

            language = DAO.GetRecordByID(id);

            if (language == null)
                return RedirectToAction("Listagem", "Person");
            return View("Form", language);
        }

        public IActionResult Salvar(LanguageViewModel language, string Operacao)
        {
            try
            {
                ValidaDados(language, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    return View("Form", language);
                }
                else
                {
                    LanguageDAO dao = new LanguageDAO();
                    if (Operacao == "A")
                        dao.Update(language);
                    else
                        dao.Add(language);
                    return RedirectToAction("index", "Person");
                }
            }
            catch (Exception erro)
            {
                ViewBag.Erro = "Ocorreu um erro: " + erro.Message;
                ViewBag.Operacao = Operacao;
                return View("Form", language);
            }
        }


        private void ValidaDados(LanguageViewModel language, string operacao)
        {
            LanguageDAO dao = new LanguageDAO();
            PersonDAO perDAO = new PersonDAO();
            if (string.IsNullOrEmpty(language.LANGUAGE_NAME))
                ModelState.AddModelError("LANGUAGE_NAME", "Nome da lingua é obrigatorio.");
            if (string.IsNullOrEmpty(language.SCHOOL_LANGUAGE_NAME))
                ModelState.AddModelError("SCHOOL_LANGUAGE_NAME", "Nome da escola de lingua é obrigatorio.");
            if (perDAO.GetRecordByCPF(language.CPF) == null) //procura o cpf na tabela person pra ver se aquele cpf é valido
                ModelState.AddModelError("CPF", "CPF invalido");
        }
    }
}