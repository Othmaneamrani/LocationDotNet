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
    }
}
