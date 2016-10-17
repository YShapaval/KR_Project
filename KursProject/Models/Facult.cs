using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace KursProject.Models
{
    public class Facult
    {
        public int FacultID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Kafedra> Kafedras { get; set; }
    }
}