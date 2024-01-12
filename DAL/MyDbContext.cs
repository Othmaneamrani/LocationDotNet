using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Demande> demandes { get; set; }
        public DbSet<Vehicule> vehicules { get; set; }
    }
}
