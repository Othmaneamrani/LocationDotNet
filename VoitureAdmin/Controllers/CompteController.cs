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
        private readonly CompteService _compteService;

        public CompteController(CompteService compteService)
        {
            _compteService = compteService;
        }

        public IActionResult Index()
        {
            List<CompteRepresentation> list = _compteService.getAll();  
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

            await _compteService.addComtpe(compteCommand);
            return RedirectToAction("Index");
        }
    }
}
