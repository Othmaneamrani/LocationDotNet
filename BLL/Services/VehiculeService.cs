using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL;
using DAL.Models;


namespace BLL.Services
{
    public class VehiculeService
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public VehiculeService(MyDbContext db , IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<VehiculeRepresentation> getAll()
        {
            return _mapper.Map<List<VehiculeRepresentation>>(_db.vehicules.ToList()) ;
        }

        public async Task addVehicule(VehiculeCommand vehiculeCommand) 
        {
            await _db.AddAsync(_mapper.Map<Vehicule>(vehiculeCommand));
            await _db.SaveChangesAsync();
        }

        public VehiculeCommand getById(long id) 
        {
            return _mapper.Map<VehiculeCommand>(_db.vehicules.Find(id));
        }

        public async Task deleteVehicule(long id)
        {
                _db.Remove(_mapper.Map<Vehicule>(await _db.vehicules.FindAsync(id)));
                await _db.SaveChangesAsync();
        }
    }
}
