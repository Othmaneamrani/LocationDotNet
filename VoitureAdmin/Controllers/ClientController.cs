using BLL.Representation;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VoitureAdmin.Controllers
{

    public class ClientController : Controller
    {

        private readonly IVehiculeService _iVehiculeService;


        public ClientController(IVehiculeService iVehiculeService)
        {
            _iVehiculeService = iVehiculeService;
        }


        [Authorize(Roles = "User")]
        public IActionResult Index(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }


        [Authorize(Roles = "User")]
        public IActionResult IndexJson(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);

            return View("Index" ,loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult PromoUserJson(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            return View("PromoUser",loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult AboutUserJson(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            return View("AboutUser",loginRepresentation);
        }


        [HttpGet]
        public IActionResult Depart()
        {
            return View(_iVehiculeService.getAll());
        }



        [HttpGet]
        public IActionResult About()
        {
            return View();
        }



        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult AboutUser(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult Profil(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }



        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult PromoUser(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }

        [HttpGet]
        public IActionResult Promo()
        {
            return View(_iVehiculeService.getAllPromo());
        }



        [HttpPost]
        public IActionResult search(string search)
        {
            var list = _iVehiculeService.searchUser(search);
            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View(null);
            }

        }

        [HttpPost]
        public IActionResult searchUser(string search)
        {
            var list = _iVehiculeService.searchUser(search);
            if (list != null)
            {
                return View(list);
            }
            else
            {
                return View(null);
            }

        }



        [HttpGet]
        public IActionResult Detail(long id)
        {
            return View(_iVehiculeService.getByIdRepresentation(id));
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult DetailUser(long id)
        {
            return View(_iVehiculeService.getByIdRepresentation(id));
        }


    }
}
