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

        public IActionResult Edit( int id)
        {
            ContactModel contact = _contactRepository.GetById(id);
            return View(contact);
        }

        public IActionResult DeleteConfirmation( int id)
        {
            ContactModel contact = _contactRepository.GetById(id);
            return View(contact);
        }
        
        public IActionResult Destroy( int id)
        {
            _contactRepository.Destroy(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Store(ContactModel contact)
        {
            _contactRepository.Adding(contact);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            _contactRepository.Update(contact);

            return RedirectToAction("Index");
        }
    }
}
