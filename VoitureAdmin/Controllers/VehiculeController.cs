﻿using AutoMapper;
using BLL.Command;
using BLL.Representation;
using BLL.Services;
using DAL.Models;
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

        [HttpGet]
        public IActionResult add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> add(VehiculeCommand vehiculeCommand) 
        {
            _vehiculeService.add(_mapper.Map<Vehicule>(vehiculeCommand));
            return RedirectToAction("Index");
        }
    }
}
