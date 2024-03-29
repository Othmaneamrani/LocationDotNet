﻿using AutoMapper;
using BLL.Command;
using BLL.Representation;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class VehiculeService : IVehiculeService
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;


        public VehiculeService(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<VehiculeRepresentation> getAll()
        {
            return _mapper.Map<List<VehiculeRepresentation>>(_db.vehicules.ToList());
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


        public VehiculeRepresentation getByIdRepresentation(long id)
        {
            return _mapper.Map<VehiculeRepresentation>(_db.vehicules.Find(id));
        }

        public async Task deleteVehicule(long id)
        {
            _db.Remove(await _db.vehicules.FindAsync(id));
            await _db.SaveChangesAsync();
        }

        public async Task updateVehicule(VehiculeCommand vehiculeCommand)
        {
            Vehicule vehicule = await _db.vehicules.FindAsync(vehiculeCommand.idCommand);
            _mapper.Map(vehiculeCommand, vehicule);
            await _db.SaveChangesAsync();
        }



        public bool GetIds(long vehiculeId)
        {
            List<Vehicule> list = _db.vehicules.ToList();
            bool ok = false;
            foreach (Vehicule vehicule in list)
            {
                if (vehicule.id == vehiculeId)
                {
                    ok = true;
                }
            }
            return ok;
        }


        public VehiculeRepresentation getPrix(long vehiculeId)
        {
            Vehicule vehicule = _db.vehicules.Find(vehiculeId);
            if (vehicule != null)
            {
                return _mapper.Map<VehiculeRepresentation>(vehicule);
            }
            else
            {
                return null;
            }

        }

        public List<VehiculeRepresentation> search (string search)
        {
            var vehicule =  _db.vehicules.Where(v => v.id.ToString() == search || v.marque.Contains(search)).ToList();
            if(vehicule != null)
            {
                return _mapper.Map <List<VehiculeRepresentation>>(vehicule);
            }
            else
            {
                return null;
            }
        }

        public List<VehiculeRepresentation> getAllPromo()
        {
            List<Vehicule> vehiculesFiltre = _db.vehicules.Where(v => v.promo.Equals("Oui")).ToList();
            return _mapper.Map <List<VehiculeRepresentation> > (vehiculesFiltre);
        }


        public List<VehiculeRepresentation> searchUser(string search)
        {
            var vehicule = _db.vehicules.Where(v => v.marque.Contains(search)).ToList();
            if (vehicule != null)
            {
                return _mapper.Map<List<VehiculeRepresentation>>(vehicule);
            }
            else
            {
                return null;
            }
        }

        public string GetMarqueById(long idVehicule)
        {
            Vehicule vehicule = _db.vehicules.Find(idVehicule);
            VehiculeRepresentation vehiculeRepresentation = _mapper.Map<VehiculeRepresentation>(vehicule);
            return vehiculeRepresentation.marqueRepresentation;
        }


        public bool estDispo(long idVehicule)
        {
            bool ok = false;
            Vehicule vehicule = _db.vehicules.Find(idVehicule);
            if(vehicule.estDispo.Equals("Oui") )
            {
                ok = true;
            }
            return ok;
        }



    }
}
