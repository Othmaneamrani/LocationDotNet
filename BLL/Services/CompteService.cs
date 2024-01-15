using AutoMapper;
using BLL.Representation;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CompteService
    {
        private readonly MyDbContext _db;  

        public CompteService(MyDbContext myDbContext)
        {
            _db = myDbContext;
        }

        public List<Compte> getAll()
        {
            List<Compte> list = _db.comptes.ToList();
            return list;
        }
    }
}
