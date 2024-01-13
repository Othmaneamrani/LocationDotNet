using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Compte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string cin { get; set; }
        [Required]
        public string telephone { get; set; }

        [InverseProperty("client")]
        public List<Demande> demandes { get; set; }
        public List<Vehicule> favoris { get; set; }
    }
}
