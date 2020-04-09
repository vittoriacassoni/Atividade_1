using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade_1.Models
{
    public class CompleteViewModel
    {
        public PersonViewModel PERSON { get; set; }
        public List<LanguageViewModel> LANGUAGE { get; set; }
        public List<ExperienceViewModel> EXPERIENCE { get; set; }
        public List<EducationalViewModel> EDUCATIONAL { get; set; }
    }
}
