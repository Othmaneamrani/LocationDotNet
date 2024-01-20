using AutoMapper;
using BLL.Command;
using BLL.Representation;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    public class VehiculeController : Controller
    {
        private readonly VehiculeService _vehiculeService;

        public VehiculeController(VehiculeService vehiculeService)
        {
            _vehiculeService = vehiculeService;
        }

        public IActionResult Index()
        {
            List<VehiculeRepresentation> list =_vehiculeService.getAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult addVehicule()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> addVehicule(VehiculeCommand vehiculeCommand)
        {
            await _vehiculeService.addVehicule(vehiculeCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult deleteVehiculeView(long id)
        {
            return View("deleteVehicule", _vehiculeService.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> deleteVehicule(long id)
        {
            await _vehiculeService.deleteVehicule(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult updateVehicule(long id)
        {
            return View(_vehiculeService.getById(id));
        }


        [HttpPost]
        public async Task<IActionResult> updateVehicule(VehiculeCommand vehiculeCommand)
        {
            await _vehiculeService.updateVehicule(vehiculeCommand);
            return RedirectToAction("Index");
        }
    }
}
