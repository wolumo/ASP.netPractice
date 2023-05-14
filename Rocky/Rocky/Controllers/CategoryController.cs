using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _db;

        public CategoryController(AplicationDbContext db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category; 
            return View(objList);
        }
        

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST- CREATE 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj); //Agrega el objeto de tipo Categoria
                _db.SaveChanges(); //Guarda los cambios
                return RedirectToAction("Index"); //Redirecciona al index
            }

            return View(obj);
        }

        // GET - EDIT 
        public IActionResult Edit (int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST- EDIT  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj); //Agrega el objeto de tipo Categoria
                _db.SaveChanges(); //Guarda los cambios
                return RedirectToAction("Index"); //Redirecciona al index
            }

            return View(obj);
        }

        //POST - Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Remove(obj); //Borrar de la base de datos 
                _db.SaveChanges(); //Guarda los cambios
                return RedirectToAction("Index"); //Redirecciona al index
            

            
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj); //RETORNA A LA VISTA CON EL MISMO NOMBRE DEL METODO , SI ES DIFF NO VA A LLEGAR
        }
    }


}
