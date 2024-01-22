using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Favoris
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [ForeignKey("compteId")]
        public long compteId { get; set; }

        [ForeignKey("vehiculeId")]
        public long vehiculeId { get; set; }


        [InverseProperty("favoris")]
        public Compte compte { get; set; }

        [InverseProperty("favoris")]
        public Vehicule vehicule { get; set; }
    }
}
