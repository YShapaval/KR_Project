using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Speciality
    {
        public int SpecialityID { get; set; }
        public string Name { get; set; }
        public int KafedraID { get; set; }
        public Kafedra Kafedra { get; set; }
        public virtual ICollection<StudyProcess> StudyProcesss { get; set; }

    }
}