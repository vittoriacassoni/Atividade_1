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
                languages = DAO.ListLanguageById(id);
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
                    if (dao.GetRecordById(language.ID_COURSE) == null)
                        dao.Add(language);
                    else
                        dao.Update(language);
                    return RedirectToAction("index");
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
            if (string.IsNullOrEmpty(language.LANGUAGE_NAME))
                ModelState.AddModelError("LANGUAGE_NAME", "Nome da lingua é obrigatorio.");
            if (string.IsNullOrEmpty(language.SCHOOL_LANGUAGE_NAME))
                ModelState.AddModelError("SCHOOL_LANGUAGE_NAME", "Nome da escola de lingua é obrigatorio."); //precisa?
            if (language.ID_COURSE < 0)
                ModelState.AddModelError("ID_COURSE", "Código precisa ser positivo.");
        }
    }
}