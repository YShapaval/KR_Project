using KursProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Kafedra
    {
        public int KafedraID { get; set; }
        public string Name { get; set; }
        public int FacultID { get; set; }
        public virtual ICollection<StudyProcess> StudyProcesss { get; set; }
        public virtual Facult Facult { get; set; }
        public virtual ICollection<Prepod> Prepods { get; set; }
        public virtual ICollection<Speciality> Specialitys { get; set; }
    }
}