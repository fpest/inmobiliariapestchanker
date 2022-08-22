using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inmobiliariaPestchanker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inmobiliariaPestchanker.Controllers
{

  
public class InquilinosController : Controller
    {

        private RepositorioInquilino repo = new RepositorioInquilino();  
        // GET: Inquilinos
        public ActionResult Index()
        {
            var lista = repo.ObtenerTodos();
            return View(lista);
        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id)
        {
              var entidad = repo.ObtenerPorId(id);
            return View(entidad);
        }

        // GET: Inquilinos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino inquilino)
        {
            try
            {
                // TODO: Add insert logic here

                repo.Alta(inquilino);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int id)
        {
               var entidad = repo.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilino inquilino)
        {
            Inquilino i = null;
            try
            {
                i = repo.ObtenerPorId(id);
                i.Nombre = inquilino.Nombre;
                i.Apellido = inquilino.Apellido;
                i.Dni = inquilino.Dni;
                i.Telefono = inquilino.Telefono;
                i.Email = inquilino.Email;
                repo.Modificacion(i);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        public ActionResult Delete(int id)
        {
               var entidad = repo.ObtenerPorId(id);
            return View(entidad);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inquilino inquilino)
        {
            try
            {
               repo.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}