using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Demande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public double prixTotal { get; set; }

        public long clientId { get; set; }
        [ForeignKey("clientId")]

        public Client client { get; set; }
        public long vehiculeId { get; set; }
        [ForeignKey("vehiculeId")]
        public Vehicule vehicule { get; set; }
    }
}
