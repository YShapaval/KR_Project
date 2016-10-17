using KursProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace KursProject.Models
{
    public class Prepod
    {
        public int PrepodID { get; set; }
        public string Name { get; set; }
        public string Dolznost { get; set; }
        public int Vozrast { get; set; }
        public int KafedraID { get; set; }
        public virtual ICollection<Discipline> Discipline { get; set; }
        public Kafedra Kafedri { get; set; }
    }
}