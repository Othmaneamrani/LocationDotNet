using BLL.Representation;
using Microsoft.AspNetCore.Mvc;

namespace VoitureAdmin.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index(LoginRepresentation loginRepresentation)
        {
            return View(loginRepresentation);
        }
    }
}
