using Microsoft.AspNetCore.Mvc;

namespace FirstAppASP.NET.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult DeleteConfirmation()
        {
            return View();
        }
        
        public IActionResult Destroy()
        {
            return View();
        }
    }
}
