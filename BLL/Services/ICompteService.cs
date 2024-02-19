using BLL.Command;
using BLL.Representation;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICompteService
    {
        public List<CompteRepresentation> getAll();
        public Task addCompte(CompteCommand compteCommand);
        public CompteCommand getById(long id);
        public Task deleteCompte(long id);
        public Task updateCompte(CompteCommand compteCommand);
        public void updateCompteRepresentation(long id, string usernameNew);
        public void updateCompteRepresentationPass(long id, string passwordNew);
        public bool getUsername(string username);
        public bool getMail(string mail);
        public bool GetIds(long compteId);
        public List<CompteRepresentation> search(string search);

        public CompteRepresentation sign (CompteCommand compteCommand);
        public CompteRepresentation login(LoginCommand loginCommand);
        public bool favoris(long idCompte , long idVehicule);

        public Task addFav(long idCompte, long idVehicule);
        public Task deleteFav(long idCompte, long idVehicule);

        public List<VehiculeRepresentation> favUser(long id);
        public List<DemandeRepresentation> mesCommandes(long id);
        public bool verifierCompte(long id , string username ,string usernameNew, string password);
        public bool verifierComptePass(long id, string password, string passwordNew);



    }
}
