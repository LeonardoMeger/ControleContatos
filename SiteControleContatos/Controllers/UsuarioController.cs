using Microsoft.AspNetCore.Mvc;

namespace SiteControleContatos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
