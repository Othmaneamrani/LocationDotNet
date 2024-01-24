using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL;
using DAL.Models;

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


        public List<CompteRepresentation> search(string search)
        {
            var compte = _db.comptes.Where(c => c.id.ToString() == search || c.username.Contains(search)).ToList();
            if (compte != null)
            {
                return _mapper.Map<List<CompteRepresentation>>(compte);
            }
            else
            {
                return null;
            }
        }

        public CompteRepresentation sign(CompteCommand compteCommand)
        {
            List<Compte> list =  _db.comptes.ToList();
            foreach(Compte compte in list)
            {
                if(compte.username.Equals(compteCommand.usernameCommand)  || compte.email.Equals(compteCommand.emailCommand))
                {
                    return null;
                }
            }

            if (compteCommand.passwordCommand.Length >= 6)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(compteCommand.telephoneCommand, @"^\d+$"))
                {
                     _db.comptes.Add(_mapper.Map<Compte>(compteCommand));
                     _db.SaveChanges();
                    return _mapper.Map<CompteRepresentation>(compteCommand);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


        public CompteRepresentation login(LoginCommand loginCommand)
        {
            List<Compte> list =  _db.comptes.ToList();
            CompteRepresentation result = null;
            foreach (Compte compte in list)
            {
                if (compte.username.Equals(loginCommand.usernameCommand) && compte.password.Equals(loginCommand.passwordCommand)
                    )
                {
                    result = _mapper.Map<CompteRepresentation>(compte);
                    break;
                }

            }
            return result;
        }



    }
}
