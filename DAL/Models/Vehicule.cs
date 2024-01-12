using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Vehicule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string type {  get; set; }
        public string marque { get; set; }
        public double kilometrage { get; set; }
        public int nombreSieges { get; set; }
        public string typeMoteur { get; set; }
        public double prix { get; set; }
        [InverseProperty("vehicule")]
        public List<Demande> demandes { get; set; }
    }
}
