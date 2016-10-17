using KursProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class StudyProcess
    {
        public int StudyProcessID { get; set; }
        public int? KafedraID { get; set; }
        public int? SpecialityID { get; set; }
        public DateTime Date { get; set; }
        public virtual Kafedra Kafedra { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Discipline Discipline  { get; set; }
    }
}