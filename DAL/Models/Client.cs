using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int age { get; set; }
        public string cin { get; set; }
        [InverseProperty("client")]
        public List<Demande> demandes { get; set; }
    }
}
