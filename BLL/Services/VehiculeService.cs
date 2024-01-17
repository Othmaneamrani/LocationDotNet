using BLL.Command;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task addVehicule(Vehicule vehicule) 
        {
            await _db.AddAsync(vehicule);
            await _db.SaveChangesAsync();
        }

        public Vehicule getById(long id) 
        {
            return _db.vehicules.Find(id);
        }

        public async Task deleteVehicule(Vehicule vehicule)
        {
                _db.Remove(vehicule);
                await _db.SaveChangesAsync();
        }
    }
}
