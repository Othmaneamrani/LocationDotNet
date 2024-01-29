using BLL.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Representation
{
    public class LoginRepresentation
    {
        public CompteRepresentation compteRepresentation { get; set; }
        public List<VehiculeRepresentation> vehiculesRepresentation { get; set; }
        public VehiculeRepresentation idVehicule {  get; set; }
        public List<VehiculeRepresentation> vehiculesSearch { get; set; }
        public DemandeCommand DemandeCommand { get; set; }
        public List<DemandeRepresentation> demandes { get; set; }
        public string ok { get; set; }

    }
}
