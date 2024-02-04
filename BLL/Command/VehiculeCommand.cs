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

        public string marqueCommand { get; set; }
        public string typeMoteurCommand { get; set; } 
        public decimal prixCommand { get; set; }
        public string estDispoCommand { get; set; }
        public string promoCommand { get; set; } = string.Empty;
        public decimal promoPrixCommand { get; set; }

    }
}
