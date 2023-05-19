using FirstAppASP.NET.Models;
using FirstAppASP.NET.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppASP.NET.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContatoController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.GetAll();

            return View(contacts);
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

        [HttpPost]
        public IActionResult Store(ContactModel contact)
        {
            _contactRepository.Adding(contact);

            return RedirectToAction("Index");
        }
    }
}
