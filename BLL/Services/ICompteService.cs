using BLL.Command;
using BLL.Representation;
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
        public Task addComtpe(CompteCommand compteCommand);
        public CompteCommand getById(long id);
        public Task deleteCompte(long id);
        public Task updateCompte(CompteCommand compteCommand);
        public bool getUsername(string username);
        public bool getMail(string mail);
        public bool GetIds(long compteId);
        public List<CompteRepresentation> search(string search);



    }
}
