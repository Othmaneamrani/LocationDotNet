﻿using BLL.Representation;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet]
        public IActionResult Depart()
        {
            return View(_iVehiculeService.getAll());
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
            return View(_iVehiculeService.getAllPromo());
        }



    }
}
