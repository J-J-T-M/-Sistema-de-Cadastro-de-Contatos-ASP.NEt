﻿using FirstAppASP.NET.Models;
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
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Adding(contact);
                    TempData["SuccessMessage"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Create", contact);
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos cadastrar o seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Update(contact);
                return RedirectToAction("Index");
            }
            return View("Edit", contact);
        }
    }
}
