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
        private readonly IDemandeService _iDemandeService;

        public DemandeController(IDemandeService iDemandeService)
        {
            _iDemandeService = iDemandeService;
        }

        public IActionResult Index()
        {
            List<DemandeRepresentation> list = _iDemandeService.getAll();
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
            await _iDemandeService.addDemande(demandeCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult deleteDemandeView(long id)
        {
            return View("deleteDemande", _iDemandeService.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> deleteDemande(long id)
        {
            await _iDemandeService.deleteDemande(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult updateDemande(long id)
        {
            return View(_iDemandeService.getById(id));
        }


        [HttpPost]
        public async Task<IActionResult> updateDemande(DemandeCommand demandeCommand)
        {
            await _iDemandeService.updateDemande(demandeCommand);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult search(long search)
        {
            var list = _iDemandeService.search(search);
            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View(null);
            }

        }




    }
}
