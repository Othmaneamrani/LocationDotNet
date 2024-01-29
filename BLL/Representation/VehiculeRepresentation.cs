using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Representation
{
    public class VehiculeRepresentation
    {
        public long idRepresentation { get; set; }
        public string photoRepresentation { get; set; }
        public string marqueRepresentation { get; set; }
        public string typeMoteurRepresentation { get; set; }
        public double prixRepresentation { get; set; }
        public string estDispoRepresentation { get; set; }
        public string promoRepresentation { get; set; } = string.Empty;
        public double promoPrixRepresentation { get; set; }

    }
}
