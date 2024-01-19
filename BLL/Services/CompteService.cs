using AutoMapper;
using BLL.Command;
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
        private readonly IMapper _mapper;


        public CompteService(MyDbContext myDbContext, IMapper mapper)
        {
            _db = myDbContext;
            _mapper = mapper;
        }

        public List<CompteRepresentation> getAll()
        {
            return _mapper.Map<List<CompteRepresentation>>(_db.comptes.ToList());
        }
        public async Task addComtpe(CompteCommand compteCommand) 
        {
            await _db.comptes.AddAsync(_mapper.Map<Compte>(compteCommand));
            await _db.SaveChangesAsync();
        }
    }
}
