using BLL.Command;
using BLL.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IVehiculeService
    {
        public List<VehiculeRepresentation> getAll();
        public Task addVehicule(VehiculeCommand vehiculeCommand);
        public VehiculeCommand getById(long id);
        public Task deleteVehicule(long id);
        public Task updateVehicule(VehiculeCommand vehiculeCommand);
        public bool GetIds(long vehiculeId);
        public VehiculeRepresentation getPrix(long vehiculeId);
        public List<VehiculeRepresentation> search (string search);
        public List<VehiculeRepresentation> getAllPromo();


    }
}
