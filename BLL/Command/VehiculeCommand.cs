using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Command
{
    public class VehiculeCommand
    {
        public long idCommand { get; set; }
        public string photoCommand { get; set; }

        public string typeCommand { get; set; }
        public string marqueCommand { get; set; }
        public double kilometrageCommand { get; set; }
        public int nombreSiegesCommand { get; set; }
        public string typeMoteurCommand { get; set; } 
        public double prixCommand { get; set; }
        public string annonceCommand { get; set; }

        public List<Demande> demandesCommand { get; set; }
    }
}
