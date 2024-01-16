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
        private readonly IMapper _mapper;

        public CompteController(CompteService compteService, IMapper mapper)
        {
            _compteService = compteService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<CompteRepresentation> list = _mapper.Map<List<CompteRepresentation>>(_compteService.getAll());
            return View(list);
        }
        [HttpGet]
        public IActionResult addCompte()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addCompte(CompteCommand compteCommand) 
        {

            _compteService.addComtpe(_mapper.Map<Compte>(compteCommand));
            return RedirectToAction("Index");
        }
    }
}
