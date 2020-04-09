using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.Models
{
    public class EducationalViewModel
    {
        [Display(Name = "Data de inicio")]
        public DateTime BEGINNING_DATE { get; set; }
        [Display(Name = "Data de termino")]
        public DateTime CONCLUSION_DATE { get; set; }
        [Display(Name = "Nome da escola")]
        public string SCHOOL_NAME { get; set; }
        [Display(Name = "Nome do curso")]
        public string COURSE_NAME { get; set; }
        [Display(Name = "CPF")]
        public string CPF_EDUCATIONAL { get; set; }
        public int ID { get; set; } //hidden
    }
}
