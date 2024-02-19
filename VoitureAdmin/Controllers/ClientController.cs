﻿using BLL.Command;
using BLL.Representation;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;

namespace VoitureAdmin.Controllers
{

    public class ClientController : Controller
    {

        private readonly IVehiculeService _iVehiculeService;
        private readonly IDemandeService _iDemandeService;
        private readonly ICompteService _iCompteService;


        public ClientController(IVehiculeService iVehiculeService, IDemandeService iDemandeService , ICompteService iCompteService)
        {
            _iVehiculeService = iVehiculeService;
            _iDemandeService = iDemandeService;
            _iCompteService = iCompteService;

        }


        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            var vehiculeList = _iVehiculeService.getAll();
            ViewBag.list = vehiculeList;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public JsonResult getPrix(long vehiculeId)
        {
            return Json(_iVehiculeService.getPrix(vehiculeId));

        }



        [HttpGet]
        public IActionResult Depart()
        {
            var vehiculeList = _iVehiculeService.getAll();
            ViewBag.list = vehiculeList;
            return View();
        }



        [HttpGet]
        public IActionResult About()
        {
            return View();
        }



        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult AboutUser()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult Profil()
        {
            return View();
        }



        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult PromoUser()
        {
            var vehiculeList = _iVehiculeService.getAllPromo();
            ViewBag.list = vehiculeList;
            return View();
        }

        [HttpGet]
        public IActionResult Promo()
        {
            var vehiculeList = _iVehiculeService.getAllPromo();
            ViewBag.list = vehiculeList;
            return View();
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
                ViewBag.list = list;
                return View();
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
        public IActionResult DetailUser(long idVehicule)
        {
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            return View(vehiculeRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult CommandeUser(long idVehicule)
        {
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            return View(vehiculeRepresentation);
        }


        [HttpPost]
        public async Task<IActionResult> addDemande(
                                           [FromForm(Name = "compteIdCommand")] long compteIdCommand,
                                           [FromForm(Name = "vehiculeIdCommand")] long vehiculeIdCommand,
                                           [FromForm(Name = "prixTotalCommand")] decimal prixTotalCommand,
                                           [FromForm(Name = "dateDebutCommand")] DateTime dateDebutCommand,
                                           [FromForm(Name = "dateFinCommand")] DateTime dateFinCommand)
        {
            DemandeCommand demandeCommand = new DemandeCommand();
            demandeCommand.compteIdCommand = compteIdCommand;
            demandeCommand.dateDebutCommand = dateDebutCommand;
            demandeCommand.dateFinCommand = dateFinCommand;
            demandeCommand.vehiculeIdCommand = vehiculeIdCommand;
            demandeCommand.prixTotalCommand = prixTotalCommand;
            await _iDemandeService.addDemande(demandeCommand);
            return View("DemandeAdded");
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult DemandeAdded()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getFavoris(long compteId , long vehiculeId)
        {
            return Json(_iCompteService.favoris(compteId, vehiculeId));

        }


        [HttpGet]
        [Authorize(Roles = "User")]

        public async Task<IActionResult> addFav(long idVehicule, long idCompte)
        {
            await _iCompteService.addFav(idCompte, idVehicule);
            return RedirectToAction("DetailUser", new { idVehicule = idVehicule });

        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> deleteFav(long idVehicule, long idCompte)
        {
            await _iCompteService.deleteFav(idCompte, idVehicule);
            return RedirectToAction("DetailUser", new { idVehicule = idVehicule });
        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> deleteFav2(long idVehicule, long idCompte)
        {
            await _iCompteService.deleteFav(idCompte, idVehicule);
            return RedirectToAction("DetailUserFav", new { idVehicule = idVehicule });
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult FavUser (long idCompte)
        {
            List < VehiculeRepresentation > listFav = _iCompteService.favUser(idCompte);
            ViewBag.FavUser = listFav;
            return View();
        }



        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult DetailUserFav(long idVehicule)
        {
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            return View(vehiculeRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult CommandeUserFav(long idVehicule)
        {
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            return View(vehiculeRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Parametre()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult MesCommandesUser(long id)
        {
            List<DemandeRepresentation> demandes = _iCompteService.mesCommandes(id);
            ViewBag.demandes = demandes;
            return View();
        }



        [HttpPost]
        public IActionResult UsernameChange([FromForm(Name = "idUser")] long idUser,
                                            [FromForm(Name = "usernameRO")] string usernameRO,
                                            [FromForm(Name = "usernameNew")] string usernameNew,
                                            [FromForm(Name = "password")] string password)
        {

            bool ok = _iCompteService.verifierCompte(idUser , usernameRO ,usernameNew, password);
            if(ok)
            {
                _iCompteService.updateCompteRepresentation(idUser,usernameNew) ;
            }
            return View("Settingz",ok);
        }

        [HttpPost]
        public IActionResult PasswordChange([FromForm(Name = "idUserPass")] long idUser,
                                            [FromForm(Name = "password")] string password,
                                            [FromForm(Name = "passwordNew")] string passwordNew)
        {

            bool ok = _iCompteService.verifierComptePass(idUser, password, passwordNew) ;
            if (ok)
            {
                _iCompteService.updateCompteRepresentationPass(idUser,passwordNew);
            }
                return View("SettingzPass",ok);

        }



        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult deleteDemandeView(long id)
        {
            return View("deleteDemande",id) ;
        }


        [HttpPost]
        public async Task<IActionResult> deleteDemandeUser(long id, long idDemande)
        {
            await _iDemandeService.deleteDemande(idDemande);

            return RedirectToAction("MesCommandesUser", new { id = id });
        }



        [HttpGet]
        public JsonResult getMarque(long vehiculeId)
        {
            return Json(_iVehiculeService.GetMarqueById(vehiculeId));

        }


        [HttpGet]
        public JsonResult EstDispo(long vehiculeId)
        {
            return Json(_iVehiculeService.estDispo(vehiculeId));

        }

    }
}
