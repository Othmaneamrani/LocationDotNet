using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL;
using DAL.Migrations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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



        public async Task addCompte(CompteCommand compteCommand)
        {
            if (compteCommand.passwordCommand.Length >= 6)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(compteCommand.telephoneCommand, @"^\d+$"))
                {
                    string hashPass = BCrypt.Net.BCrypt.HashPassword(compteCommand.passwordCommand);
                    compteCommand.passwordCommand = hashPass;
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
            string hashPass = BCrypt.Net.BCrypt.HashPassword(compteCommand.passwordCommand);
            compteCommand.passwordCommand = hashPass;
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
            long nbr = 0;

            foreach(Compte compte in list)
            {
                if (compte.username.Equals(compteCommand.usernameCommand)  || compte.email.Equals(compteCommand.emailCommand))
                {
                    return null;
                }
            }

            if (compteCommand.passwordCommand.Length >= 6)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(compteCommand.telephoneCommand, @"^\d+$"))
                {
                    string hashPass = BCrypt.Net.BCrypt.HashPassword(compteCommand.passwordCommand);
                    compteCommand.passwordCommand = hashPass;
                     _db.comptes.Add(_mapper.Map<Compte>(compteCommand));
                     _db.SaveChanges();
                    List<Compte> list2 = _db.comptes.ToList();
                    foreach (Compte compte2 in list2)
                    {
                        if (compte2.id > nbr)
                        {
                            nbr = compte2.id;
                        }
                    }

                    CompteRepresentation compteRepresentation = _mapper.Map<CompteRepresentation>(compteCommand);
                    compteRepresentation.idRepresentation = nbr;
                    return compteRepresentation;
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
            string hashPass = BCrypt.Net.BCrypt.HashPassword("aaaaaa");
            if (loginCommand.usernameCommand.Equals("hotman") && BCrypt.Net.BCrypt.Verify(loginCommand.passwordCommand, hashPass)) 
            {
                return new CompteRepresentation { usernameRepresentation = "anaRaniAdmin" };
            }
            foreach (Compte compte in list)
            {
                if (compte.username.Equals(loginCommand.usernameCommand) && BCrypt.Net.BCrypt.Verify(loginCommand.passwordCommand , compte.password ))
                {
                    result = _mapper.Map<CompteRepresentation>(compte);
                    break;
                }

            }
            return result;
        }

        public bool favoris(long idCompte, long idVehicule)
        {
            bool ok = false;
            List<Favoris> list = _db.favoris.ToList();
            foreach (Favoris favoris in list)
            {
                if(favoris.compteId == idCompte && favoris.vehiculeId == idVehicule)
                {
                    ok = true;
                    break;
                }
            }
            return ok;
        }

        public async Task addFav(long idCompte, long idVehicule)
        {
            Favoris favoris = new Favoris();
            favoris.compteId = idCompte;
            favoris.vehiculeId = idVehicule;
            await _db.favoris.AddAsync(favoris);
            await _db.SaveChangesAsync();
        }

        public async Task deleteFav(long idCompte, long idVehicule)
        {
            List<Favoris> list = await _db.favoris.ToListAsync();
            foreach (Favoris favoris in list)
            {
                if (favoris.compteId == idCompte && favoris.vehiculeId == idVehicule)
                {
                    _db.favoris.Remove(favoris);
                    await _db.SaveChangesAsync();
                    break;
                }
            }
        }



        public List<VehiculeRepresentation> favUser(long id )
        {
            List<Favoris> favs = _db.favoris.ToList();
            List<Favoris> favs2 = new List<Favoris>();
            List<VehiculeRepresentation> result = new List<VehiculeRepresentation>();
            foreach (var fav in favs)
            {
                if(fav.compteId == id)
                {
                    favs2.Add(fav);
                }
            }
            List<Vehicule> vehicules = _db.vehicules.ToList();
            foreach(var vehicule in vehicules)
            {
                foreach(var fav in favs2)
                {
                    if (vehicule.id == fav.vehiculeId)
                    {
                        result.Add(_mapper.Map<VehiculeRepresentation>(vehicule));
                    }

                }
            }
            return result;
        }



        public List<DemandeRepresentation> mesCommandes(long id)
        {
            List<Demande> mesCommandes = _db.demandes.ToList();
            List<Demande> result = new List<Demande>();
            foreach (var demande in mesCommandes)
            {
                if(demande.compteId == id)
                {
                    result.Add(demande);
                }
            }
            return _mapper.Map<List<DemandeRepresentation>>(result);
        }

        public bool verifierCompte(long id, string username,string usernameNew, string password)
        {
            bool ok = true;
            List<Compte> compteList = _db.comptes.ToList();
            Compte khouna = _db.comptes.Find(id);
            if (!BCrypt.Net.BCrypt.Verify(password, khouna.password) || !khouna.username.Equals(username)){
                ok = false;
            }
            foreach (var compte in compteList)
            {
                if(compte.username.Equals(usernameNew))
                {
                    ok = false;
                }
            }
            return ok;
        }


        public bool verifierComptePass(long id, string password ,string passwordNew)
        {
            bool ok = true;
            Compte khouna = _db.comptes.Find(id);
            if (!BCrypt.Net.BCrypt.Verify(password, khouna.password) || passwordNew.Length < 6  )
            {
                ok = false;
            }
            return ok;
        }



        public void updateCompteRepresentation(long id, string usernameNew)
        {
            Compte compte = _db.comptes.Find(id);
            compte.username = usernameNew;
            CompteCommand compteCommand = _mapper.Map<CompteCommand>(compte);
            _mapper.Map(compteCommand, compte);
            _db.SaveChanges();
        }


        public void updateCompteRepresentationPass(long id, string passwordNew)
        {
            Compte compte = _db.comptes.Find(id);
            compte.password = BCrypt.Net.BCrypt.HashPassword(passwordNew);
            CompteCommand compteCommand = _mapper.Map<CompteCommand>(compte);
            _mapper.Map(compteCommand, compte);
            _db.SaveChanges();
        }

    }
}
