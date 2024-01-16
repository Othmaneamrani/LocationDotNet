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
        private readonly IMapper _mapper;
        private readonly DemandeService _demandeService;

        public DemandeController(IMapper mapper, DemandeService demandeService)
        {
            _mapper = mapper;
            _demandeService = demandeService;
        }

        public IActionResult Index()
        {
            List<DemandeRepresentation> list = _mapper.Map<List<DemandeRepresentation>>(_demandeService.getAll());
            return View(list);
        }
        [HttpGet]
        public IActionResult addDemande()
        {
            return View();
        }


        [HttpPost]
        public IActionResult addDemande(DemandeCommand demandeCommand)
        {
            _demandeService.addDemande(_mapper.Map<Demande>(demandeCommand));
            return RedirectToAction("Index");
        }
    }
}
