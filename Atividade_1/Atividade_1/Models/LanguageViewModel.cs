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
        [Display(Name = "CPF")]
        public string CPF { get; set; }
        public int ID { get; set; } //hidden
    }
}
