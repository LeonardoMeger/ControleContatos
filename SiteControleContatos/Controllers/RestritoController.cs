using Microsoft.AspNetCore.Mvc;
using SiteControleContatos.Filters;

namespace SiteControleContatos.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaParaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
