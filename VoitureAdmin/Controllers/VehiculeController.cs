using BLL.Command;
using BLL.Representation;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VehiculeController : Controller
    {
        private readonly IVehiculeService _iVehiculeService;


        public VehiculeController(IVehiculeService iVehiculeService)
        {
            _iVehiculeService = iVehiculeService;
        }

        public IActionResult Index()
        {
            List<VehiculeRepresentation> list =_iVehiculeService.getAll();
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
            await _iVehiculeService.addVehicule(vehiculeCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult deleteVehiculeView(long id)
        {
            return View("deleteVehicule", _iVehiculeService.getById(id));
        }

        [HttpPost]
        public async Task<IActionResult> deleteVehicule(long id)
        {
            await _iVehiculeService.deleteVehicule(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult updateVehicule(long id)
        {
            return View(_iVehiculeService.getById(id));
        }


        [HttpPost]
        public async Task<IActionResult> updateVehicule(VehiculeCommand vehiculeCommand)
        {
            await _iVehiculeService.updateVehicule(vehiculeCommand);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult CheckId(long vehiculeId)
        {
            bool isIdAvailable = _iVehiculeService.GetIds(vehiculeId);
            return Json(isIdAvailable);
        }
        [HttpGet]
        public JsonResult getPrix(long vehiculeId)
        {
            return Json(_iVehiculeService.getPrix(vehiculeId) );

        }



        [HttpPost]
        public IActionResult search (string search)
        {
            var list = _iVehiculeService.search(search);
            if(list != null)
            {           
                return View(list);
            }
            else
            {
                return View(null);
            }

        }


        public JsonResult GetVehicules()
        {
            return Json(_iVehiculeService.getAll());
        }

    }
}
