using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Representation
{
    public class CompteRepresentation
    {
        public long idRepresentation { get; set; }
        public string usernameRepresentation { get; set; }
        public string passwordRepresentation { get; set; }
        public string nomRepresentation { get; set; }
        public string prenomRepresentation { get; set; }
        public int ageRepresentation { get; set; }
        public string emailRepresentation { get; set; }
        public string cinRepresentation { get; set; }
        public string telephoneRepresentation { get; set; }

        public List<Demande> demandesRepresentation { get; set; }
        public List<Vehicule> favorisRepresentation { get; set; }
    }
}
