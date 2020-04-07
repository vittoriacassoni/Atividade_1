﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade_1.DAO;
using Atividade_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            PersonDAO DAO = new PersonDAO();
            List<PersonViewModel> list = DAO.List();
            return View(list);
        }
        public ActionResult Details(string id)
        {
            try
            {
                PersonDAO person = new PersonDAO();
                person.GetRecordById(id);
                return View(person);
            }
            catch (Exception erro)
            {
                throw;
            }
        }

        public IActionResult Create()
        {
            ViewBag.Operacao = "I";
            PersonViewModel person = new PersonViewModel();

            PersonDAO DAO = new PersonDAO();

            return View("Form", person);
        }

        private void ValidaDados(PersonViewModel person, string operacao)
        {
            PersonDAO dao = new PersonDAO();
            if (operacao == "I" && dao.GetRecordById(person.CPF) != null)
                ModelState.AddModelError("CPF", "CPF já cadastrado.");
            if (operacao == "A" && dao.GetRecordById(person.CPF) == null)
                ModelState.AddModelError("CPF", "CPF não cadastrado.");
            if (string.IsNullOrEmpty(person.NAME))
                ModelState.AddModelError("NAME", "Nome é obrigatorio.");
            if (person.DATE_OF_BIRTH > DateTime.Now)
                ModelState.AddModelError("DATE_OF_BIRTH", "Data de nascimento não pode ser maior que a data atual");
            if (string.IsNullOrEmpty(person.TELEPHONE))
                ModelState.AddModelError("TELEPHONE", "Telefone é obrigatorio.");
            if (string.IsNullOrEmpty(person.EMAIL_ADDRESS))
                ModelState.AddModelError("EMAIL_ADDRESS", "E-mail é obrigatorio.");
            if (person.PRETENSION_SALARY < 0)
                ModelState.AddModelError("PRETENSION_SALARY", "Pretensão salarial não pode ser numero negativo.");
            if (string.IsNullOrEmpty(person.INTENDED_POSITION))
                ModelState.AddModelError("INTENDED_POSITION", "Cargo pretendido é obrigatorio.");
        }
    }
}