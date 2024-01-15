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
    public class DemandeCommand
    {
        public long idCommand { get; set; }
        public DateTime dateDebutCommand { get; set; }
        public DateTime dateFinCommand { get; set; }
        public double prixTotalCommand { get; set; }

        public long compteIdCommand { get; set; }

        public Compte compteCommand { get; set; }
        public long vehiculeIdCommand { get; set; }
        public Vehicule vehiculeCommand { get; set; }
    }
}
