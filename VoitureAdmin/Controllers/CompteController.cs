using AutoMapper;
using BLL.Command;
using BLL.Representation;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    public class CompteController : Controller
    {
        private readonly ICompteService _iCompteService;

        public CompteController(ICompteService iCompteService)
        {
            _iCompteService = iCompteService;
        }

        public IActionResult Index()
        {
            List<CompteRepresentation> list = _iCompteService.getAll();  
            return View(list);
        }
        [HttpGet]
        public IActionResult addCompte()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addCompte(CompteCommand compteCommand)
        {
            await _iCompteService.addComtpe(compteCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult deleteCompteView(long id)
        {
            return View("deleteCompte", _iCompteService.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> deleteCompte(long id)
        {
            await _iCompteService.deleteCompte(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult updateCompte(long id)
        {
            return View(_iCompteService.getById(id));
        }


        [HttpPost]
        public async Task<IActionResult> updateCompte(CompteCommand compteCommand)
        {
            await _iCompteService.updateCompte(compteCommand);
            return RedirectToAction("Index");
        }
    }
}
