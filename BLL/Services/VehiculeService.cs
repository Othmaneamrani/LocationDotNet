using BLL.Command;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VehiculeService
    {
        private readonly MyDbContext _db;

        public VehiculeService(MyDbContext db)
        {
            _db = db;
        }

        public List<Vehicule> getAll()
        {
            List<Vehicule> list = _db.vehicules.ToList();
            return list;
        }

        public void add(Vehicule vehicule) 
        {
             _db.AddAsync(vehicule);
            _db.SaveChangesAsync();
        }
    }
}
