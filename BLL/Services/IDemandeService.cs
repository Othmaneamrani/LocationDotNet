using BLL.Command;
using BLL.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IDemandeService
    {
        public List<DemandeRepresentation> getAll();
        public Task addDemande(DemandeCommand demandeCommand);
        public DemandeCommand getById(long id);
        public Task deleteDemande(long id);
        public Task updateDemande(DemandeCommand demandeCommand);
        public DemandeRepresentation search(long search);



    }
}
