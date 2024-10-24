using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formularios.DataAccess;
using Formularios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Formularios.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contactos = _context.contactos.ToList();
            return View(contactos);
        }

        public IActionResult CreateContacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContacto(Contacto contacto)
        {   
            if(!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    var fieldName = entry.Key;  // Nombre del campo que falló la validación
                    var state = entry.Value;
                    // Recorre todos los errores asociados a ese campo
                    foreach (var error in state.Errors)
                    {
                        var errorMessage = error.ErrorMessage;  // Mensaje de error que describe qué falló
                        Console.WriteLine($"Error en el campo {fieldName}: {errorMessage}");
                    }
                }
                Console.WriteLine("--------------");
                return View(contacto);  
            }
            _context.contactos.Add(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}