using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}