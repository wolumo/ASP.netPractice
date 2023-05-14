 using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections;
using System.Collections.Generic;

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
            _db.AplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
