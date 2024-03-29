﻿using System;
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
        [Required]
        public string photo { get; set; }
        [Required]
        public string marque { get; set; }
        [Required]
        public string typeMoteur { get; set; } //manuelle ou automatique
        [Required]
        public decimal prix { get; set; }
        [Required]
        public string estDispo { get; set; } //vente ou location
        public string promo { get; set; } = string.Empty;
        public decimal promoPrix { get; set; }

    }
}
