using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.Models
{
    public class LanguageViewModel
    {
        [Display(Name = "Idioma")]
        public string LANGUAGE_NAME { get; set; }
        [Display(Name = "Nome da escola")]
        public string SCHOOL_LANGUAGE_NAME { get; set; }
        [Display(Name = "Codigo do curso")]
        public int ID_COURSE { get; set; }
    }
}
