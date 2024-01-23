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
    public class CompteService : ICompteService
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
            if (compteCommand.passwordCommand.Length > 6)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(compteCommand.telephoneCommand, @"^\d+$"))
                {
                    await _db.comptes.AddAsync(_mapper.Map<Compte>(compteCommand));
                    await _db.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Le numéro de téléphone doit contenir uniquement des chiffres.");
                }
            }
            else
            {
                throw new ArgumentException("Le password est invalide.");
            }
        }

        public CompteCommand getById(long id)
        {
            return _mapper.Map<CompteCommand>(_db.comptes.Find(id));
        }

        public async Task deleteCompte(long id)
        {
            _db.Remove(await _db.comptes.FindAsync(id));
            await _db.SaveChangesAsync();
        }

        public async Task updateCompte(CompteCommand compteCommand)
        {
            Compte compte = await _db.comptes.FindAsync(compteCommand.idCommand);
            _mapper.Map(compteCommand, compte);
            await _db.SaveChangesAsync();
        }


        public bool getUsername(string username)
        {
            List<Compte> list = _db.comptes.ToList();
            bool ok=true;
            foreach (Compte compte in list)
            {
                if(compte.username == username)
                {
                    ok = false;
                }
            }
            return ok;
        }


        public bool getMail(string mail)
        {
            List<Compte> list = _db.comptes.ToList();
            bool ok = true;
            foreach (Compte compte in list)
            {
                if (compte.email == mail)
                {
                    ok = false;
                }
            }
            return ok;
        }


        public bool GetIds(long compteId)
        {
            List<Compte> list = _db.comptes.ToList();
            bool ok = false;
            foreach (Compte compte in list)
            {
                if (compte.id == compteId)
                {
                    ok = true;
                }
            }
            return ok;
        }
    }
}
