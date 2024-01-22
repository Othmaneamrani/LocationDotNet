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

        public long compteId { get; set; }

        public long vehiculeId { get; set; }

        [ForeignKey("compteId")]
        public Compte compte { get; set; }

        [ForeignKey("vehiculeId")]
        public Vehicule vehicule { get; set; }
    }
}
