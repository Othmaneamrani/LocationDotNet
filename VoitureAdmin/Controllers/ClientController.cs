using BLL.Representation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    [Authorize(Roles = "User")]

    public class ClientController : Controller
    {
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
        public IActionResult AboutUser(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }


    }
}
