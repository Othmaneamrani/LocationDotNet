using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DemandeService
    {
        private readonly MyDbContext _db;

        public DemandeService(MyDbContext db)
        {
            _db = db;
        }

        public List<Demande> getAll()
        {
            List<Demande> list = _db.demandes.ToList();
            return list;
        }
    }
}
