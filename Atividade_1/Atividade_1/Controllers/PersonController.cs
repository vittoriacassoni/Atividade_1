using System;
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
    }
}