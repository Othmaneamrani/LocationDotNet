using BLL.Command;
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
        private readonly IDemandeService _iDemandeService;
        private readonly ICompteService _iCompteService;


        public ClientController(IVehiculeService iVehiculeService, IDemandeService iDemandeService , ICompteService iCompteService)
        {
            _iVehiculeService = iVehiculeService;
            _iDemandeService = iDemandeService;
            _iCompteService = iCompteService;

        }


        [Authorize(Roles = "User")]
        public IActionResult Index(LoginRepresentation loginRepresentation)
        {
            var vehiculeList = _iVehiculeService.getAll();
            ViewBag.list = vehiculeList;
            return View(loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public JsonResult getPrix(long vehiculeId)
        {
            return Json(_iVehiculeService.getPrix(vehiculeId));

        }


        [Authorize(Roles = "User")]
        public IActionResult IndexJson(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);

            return View("Index", loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult PromoUserJson(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            return View("PromoUser", loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult AboutUserJson(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            return View("AboutUser", loginRepresentation);
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

        public IActionResult AboutUser(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]

        public IActionResult Profil(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
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
        public IActionResult searchUser(string search, string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            loginRepresentation.vehiculesSearch = _iVehiculeService.searchUser(search);
            if (loginRepresentation.vehiculesSearch != null)
            {
                return View(loginRepresentation);
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
        public IActionResult DetailUser(long idVehicule, string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            loginRepresentation.idVehicule = vehiculeRepresentation;
            return View(loginRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult CommandeUser(long idVehicule, string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            loginRepresentation.idVehicule = vehiculeRepresentation;
            return View(loginRepresentation);
        }


        [HttpPost]
        public async Task<IActionResult> addDemande(string loginJson,
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
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            await _iDemandeService.addDemande(demandeCommand);
            return View("DemandeAdded",loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult DemandeAdded(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }

        [HttpGet]
        public JsonResult getFavoris(long compteId , long vehiculeId)
        {
            return Json(_iCompteService.favoris(compteId, vehiculeId));

        }


        [HttpGet]
        [Authorize(Roles = "User")]

        public async Task<IActionResult> addFav(string loginJson)
        {
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            await _iCompteService.addFav(loginRepresentation.compteRepresentation.idRepresentation, loginRepresentation.idVehicule.idRepresentation);
            return View("DetailUser", loginRepresentation);

        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> deleteFav(string loginJson)
        {
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            await _iCompteService.deleteFav(loginRepresentation.compteRepresentation.idRepresentation, loginRepresentation.idVehicule.idRepresentation);
            return View("DetailUser", loginRepresentation);
        }


        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> deleteFav2(string loginJson)
        {
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            await _iCompteService.deleteFav(loginRepresentation.compteRepresentation.idRepresentation, loginRepresentation.idVehicule.idRepresentation);
            return View("DetailUserFav", loginRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult FavUser (string loginJson)
        {
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            loginRepresentation.vehiculesSearch = _iCompteService.favUser(loginRepresentation.compteRepresentation);
            return View(loginRepresentation);
        }



        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult DetailUserFav(long idVehicule, string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            loginRepresentation.idVehicule = vehiculeRepresentation;
            return View(loginRepresentation);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult CommandeUserFav(long idVehicule, string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            VehiculeRepresentation vehiculeRepresentation = _iVehiculeService.getByIdRepresentation(idVehicule);
            loginRepresentation.idVehicule = vehiculeRepresentation;
            return View(loginRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Parametre(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            return View(loginRepresentation);
        }


        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult MesCommandesUser(string loginJson)
        {
            var loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            loginRepresentation.demandes = _iCompteService.mesCommandes(loginRepresentation.compteRepresentation.idRepresentation);
            return View(loginRepresentation);
        }



        [HttpPost]
        public IActionResult UsernameChange(string loginJson,
                                   [FromForm(Name = "usernameNew")] string usernameNew,
                                   [FromForm(Name = "password")] string password)
        {

            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            bool ok = _iCompteService.verifierCompte(loginRepresentation.compteRepresentation , usernameNew , password);
            if(ok)
            {
                loginRepresentation.ok = "ah";
                loginRepresentation.compteRepresentation.usernameRepresentation = usernameNew;
                _iCompteService.updateCompteRepresentation(loginRepresentation.compteRepresentation);
                return View("settingz", loginRepresentation);

            }
            else
            {
                loginRepresentation.ok = "la";
                return View("settingz", loginRepresentation);
            }

        }

        [HttpPost]
        public IActionResult PasswordChange(string loginJson,
                                                      [FromForm(Name = "password")] string password,
                                                      [FromForm(Name = "passwordNew")] string passwordNew)
        {

            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            bool ok = _iCompteService.verifierComptePass(loginRepresentation.compteRepresentation, password, passwordNew);
            if (ok)
            {
                loginRepresentation.ok = "ah";
                loginRepresentation.compteRepresentation.passwordRepresentation = passwordNew;
                _iCompteService.updateCompteRepresentationPass(loginRepresentation.compteRepresentation);
                return View("settingzPass", loginRepresentation);

            }
            else
            {
                loginRepresentation.ok = "la";
                return View("settingzPass", loginRepresentation);
            }

        }



        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult deleteDemandeView(long id ,string loginJson)
        {
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            loginRepresentation.demandeId = id;
            return View("deleteDemande", loginRepresentation) ;
        }


        [HttpPost]
        public async Task<IActionResult> deleteDemandeUser(string loginJson)
        {
            LoginRepresentation loginRepresentation = JsonConvert.DeserializeObject<LoginRepresentation>(loginJson);
            await _iDemandeService.deleteDemande(loginRepresentation.demandeId);
            for (int i = loginRepresentation.demandes.Count - 1; i >= 0; i--)
            {
                if (loginRepresentation.demandes[i].idRepresentation == loginRepresentation.demandeId)
                {
                    loginRepresentation.demandes.RemoveAt(i);
                }
            }
            return View("MesCommandesUser", loginRepresentation);
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
