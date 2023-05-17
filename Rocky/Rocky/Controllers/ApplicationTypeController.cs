 using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly AplicationDbContext _db;

        public ApplicationTypeController (AplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<AplicationType> objList = _db.AplicationType;
            return View(objList);
        }


        //GET - CREATE 
        public IActionResult Create()
        {
            return View();
        }

        //  POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (AplicationType obj)
        {

            if (ModelState.IsValid)
            {


                _db.AplicationType.Add(obj);
                _db.SaveChanges();
            }else
            {
                IEnumerable<string> errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
            }
            return RedirectToAction("Index");

        }

        //GET - EDIT 
        public IActionResult Edit (int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var obj = _db.AplicationType.Find(id);
            if(obj == null)
            {
                return NotFound(); 
            }
            return View(obj);
        }

        //POST - EDIT 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (AplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.AplicationType.Update(obj); //Agregando el objeto de tipo ApplicationType
                _db.SaveChanges(); //Guardando Cambios
                return RedirectToAction("Index"); //Redireccionando al index
            }

            return View(obj);
        }

        //GET-DELETE
        public IActionResult Delete (int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var obj = _db.AplicationType.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int? id)
        {
            var obj = _db.AplicationType.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
