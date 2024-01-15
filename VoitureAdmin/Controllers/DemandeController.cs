using AutoMapper;
using BLL.Representation;
using BLL.Services;
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
    }
}
