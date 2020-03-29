using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.Models
{
    public class EducationalViewModel
    {
        public int ID_COURSE { get; set; }
        public DateTime BEGINNING_DATE { get; set; }
        public DateTime CONCLUSION_DATE { get; set; }
        public string SCHOOL_NAME { get; set; }
        public string COURSE_NAME { get; set; }
        public string CPF_EDUCATIONAL { get; set; }
    }
}
