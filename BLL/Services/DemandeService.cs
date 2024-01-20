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
    public class DemandeService : IDemandeService
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;


        public DemandeService(MyDbContext db , IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<DemandeRepresentation> getAll()
        {
            List<Demande> list = _db.demandes.ToList();
            return _mapper.Map<List<DemandeRepresentation>>(_db.demandes.ToList());
        }

        public async Task addDemande(DemandeCommand demandeCommand)
        {
            await _db.demandes.AddAsync(_mapper.Map<Demande>(demandeCommand));
            await _db.SaveChangesAsync();
        }

        public DemandeCommand getById(long id)
        {
            return _mapper.Map<DemandeCommand>(_db.demandes.Find(id));
        }

        public async Task deleteDemande(long id)
        {
            _db.Remove(await _db.demandes.FindAsync(id));
            await _db.SaveChangesAsync();
        }

        public async Task updateDemande(DemandeCommand demandeCommand)
        {
            Demande demande = await _db.demandes.FindAsync(demandeCommand.idCommand);
            _mapper.Map(demandeCommand, demande);
            await _db.SaveChangesAsync();
        }

    }
}
