using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace KursProject.Models
{
    public class Discipline
    {
        public int DisciplineID { get; set; }
        public string Name { get; set; }
        public int KolichPract { get; set; }
        public int KolichLab { get; set; }
        public int PrepodID { get; set; }
        public int Kurs { get; set; }
        public int Semestr { get; set; }
        public string VidOtchet { get; set; }
        public virtual ICollection<StudyProcess> StudyProcesss { get; set; }
        public Prepod Prepods { get; set; }
    }
}