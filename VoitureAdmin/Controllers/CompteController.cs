using AutoMapper;
using BLL.Command;
using BLL.Representation;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VoitureAdmin.Controllers
{

    public class CompteController : Controller
    {
        private readonly ICompteService _iCompteService;
        private readonly IVehiculeService _iVehiculeService;

        public CompteController(ICompteService iCompteService , IVehiculeService iVehiculeService)
        {
            _iCompteService = iCompteService;
            _iVehiculeService = iVehiculeService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<CompteRepresentation> list = _iCompteService.getAll();  
            return View(list);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult addCompte()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> addCompte(CompteCommand compteCommand)
        {
            bool ok = _iCompteService.getUsername(compteCommand.usernameCommand);
            if (ok)
            {
                await _iCompteService.addCompte(compteCommand);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult deleteCompteView(long id)
        {
            return View("deleteCompte", _iCompteService.getById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> deleteCompte(long id)
        {
            await _iCompteService.deleteCompte(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult updateCompte(long id)
        {
            return View(_iCompteService.getById(id));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> updateCompte(CompteCommand compteCommand)
        {
            await _iCompteService.updateCompte(compteCommand);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult CheckUsername(string username)
        {
            bool isUsernameAvailable = _iCompteService.getUsername(username);
            return Json(isUsernameAvailable);
        }

        [HttpGet]

        public JsonResult CheckMail(string mail)
        {
            bool isMailAvailable = _iCompteService.getMail(mail);
            return Json(isMailAvailable);
        }


        [HttpGet]

        public JsonResult CheckUsernameUpdate(string username,string usernameCommand)
        {
            bool isUsernameAvailable=true;
            if (!string.IsNullOrEmpty(usernameCommand) && username != usernameCommand)
            {
                isUsernameAvailable = _iCompteService.getUsername(username);
            }
            return Json(isUsernameAvailable);
        }

        [HttpGet]
        public JsonResult CheckMailUpdate(string mail, string mailCommand)
        {
            bool isMailAvailable = true;
            if (!string.IsNullOrEmpty(mailCommand) && mail != mailCommand)
            {
                isMailAvailable = _iCompteService.getMail(mail);
            }
            return Json(isMailAvailable);
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sign()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CheckId(long compteId)
        {
            bool isIdAvailable = _iCompteService.GetIds(compteId);
            return Json(isIdAvailable);
        }

        [HttpPost]
        public IActionResult search(string search)
        {
            var list = _iCompteService.search(search);
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
        public IActionResult Sign(CompteCommand compteCommand) 
        {
            CompteRepresentation result = _iCompteService.sign(compteCommand);
            if(result != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.usernameRepresentation),
                    new Claim(ClaimTypes.Role, "User")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                List<VehiculeRepresentation> vehiculesRepresentation = _iVehiculeService.getAll();
                LoginRepresentation loginRepresentation = new LoginRepresentation();
                loginRepresentation.compteRepresentation = result;
                loginRepresentation.vehiculesRepresentation = vehiculesRepresentation;

                return View("goodSign", loginRepresentation);
            }
            return View();
        }



        [HttpPost]
        public IActionResult Login(LoginCommand loginCommand)
        {
            CompteRepresentation result = _iCompteService.login(loginCommand);
            if (result != null)
            {
                if (result.usernameRepresentation.Equals("anaRaniAdmin"))
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.usernameRepresentation),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    List<VehiculeRepresentation> vehiculesRepresentation = _iVehiculeService.getAll();
                    LoginRepresentation loginRepresentation = new LoginRepresentation();
                    loginRepresentation.compteRepresentation = result;
                    loginRepresentation.vehiculesRepresentation = vehiculesRepresentation;
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.usernameRepresentation),
                        new Claim(ClaimTypes.Role, "User")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    return View("~/Views/Client/Index.cshtml", loginRepresentation);
                }
            }else
            {
                return View("falseLogin");
            }
        }


        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction("Login", "Compte");
        }




        public IActionResult Acces()
        {
            return View();
        }



    }
}
