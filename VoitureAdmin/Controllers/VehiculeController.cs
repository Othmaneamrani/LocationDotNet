using AutoMapper;
using BLL.Representation;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    public class VehiculeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly VehiculeService _vehiculeService;

        public VehiculeController(IMapper mapper, VehiculeService vehiculeService)
        {
            _mapper = mapper;
            _vehiculeService = vehiculeService;
        }

        public IActionResult Index()
        {
            List<VehiculeRepresentation> list = _mapper.Map<List<VehiculeRepresentation>>(_vehiculeService.getAll());
            return View(list);
        }
    }
}
