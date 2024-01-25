using BLL.Representation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    [Authorize(Roles = "User")]

    public class ClientController : Controller
    {
        [Authorize(Roles = "User")]

        public IActionResult Index(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }



        [HttpGet]
        public IActionResult Depart()
        {
            return View();
        }


        [HttpPost]

        public IActionResult redirectIndex(LoginRepresentation loginRepresentation)
        {

            return RedirectToAction("Index" , loginRepresentation);
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
            return View();
        }



    }
}
