using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.Models
{
    public class ExperienceViewModel
    {
        [Display(Name = "Nome da empresa")]
        public string COMPANY_NAME { get; set; }
        [Display(Name = "Cargo anterior")]
        public string PREVIOUS_POSITION { get; set; }
        [Display(Name = "Salario anterior")]
        public double PREVIOUS_SALARY { get; set; }
        [Display(Name = "CPF")]
        public string CPF_EXPERIENCE { get; set; }
    }
}
