using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Representation
{
    public class DemandeRepresentation
    {
        public long idRepresentation { get; set; }
        public DateTime dateDebutRepresentation { get; set; }
        public DateTime dateFinRepresentation { get; set; }
        public decimal prixTotalRepresentation { get; set; }

        public long compteIdRepresentation { get; set; }

        public Compte compteRepresentation { get; set; }
        public long vehiculeIdRepresentation { get; set; }
        public Vehicule vehiculeRepresentation { get; set; }
    }
}
