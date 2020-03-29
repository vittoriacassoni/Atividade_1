using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.Models
{
    public class PersonViewModel
    {
        [Display(Name = "CPF")]
        public string CPF { get; set; }
        [Display(Name = "Nome")]
        public string NAME { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DATE_OF_BIRTH { get; set; }
        [Display(Name = "Endereço")]
        public string HOME_ADDRESS { get; set; }
        [Display(Name = "Telefone")]
        public string TELEPHONE { get; set; }
        [Display(Name = "E-mail")]
        public string EMAIL_ADDRESS { get; set; }
        [Display(Name = "Pretensão Salarial")]
        public double PRETENSION_SALARY { get; set; }
        [Display(Name = "Cargo Pretendido")]
        public string INTENDED_POSITION { get; set; }
    }
}
