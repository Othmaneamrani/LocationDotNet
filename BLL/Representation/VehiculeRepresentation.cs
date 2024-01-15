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
        public byte[] photoRepresentation { get; set; }
        public string typeRepresentation { get; set; }
        public string marqueRepresentation { get; set; }
        public double kilometrageRepresentation { get; set; }
        public int nombreSiegesRepresentation { get; set; }
        public string typeMoteurRepresentation { get; set; }
        public double prixRepresentation { get; set; }
        public string annonceRepresentation { get; set; }
        public List<Demande> demandesRepresentation { get; set; }
    }
}
