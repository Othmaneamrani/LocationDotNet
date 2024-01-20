using AutoMapper;
using BLL.Command;
using BLL.Representation;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    public class DemandeController : Controller
    {
        private readonly DemandeService _demandeService;

        public DemandeController(DemandeService demandeService)
        {
            _demandeService = demandeService;
        }

        public IActionResult Index()
        {
            List<DemandeRepresentation> list =_demandeService.getAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult addDemande()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> addDemande(DemandeCommand demandeCommand)
        {
            await _demandeService.addDemande(demandeCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult deleteDemandeView(long id)
        {
            return View("deleteDemande", _demandeService.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> deleteDemande(long id)
        {
            await _demandeService.deleteDemande(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult updateDemande(long id)
        {
            return View(_demandeService.getById(id));
        }


        [HttpPost]
        public async Task<IActionResult> updateDemande(DemandeCommand demandeCommand)
        {
            await _demandeService.updateDemande(demandeCommand);
            return RedirectToAction("Index");
        }
    }
}
