using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroProject.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Person

        public ActionResult Index()
        {
            var SuperHeros = db.SuperHeros.ToList();
            
            return View(SuperHeros);
        }
        public ActionResult Create()
        {
            var SuperHeros = db.SuperHeros.ToList();
            return View();
        }
        public ActionResult Create(SuperHeros superHeros)
        {
            var SuperHeros = db.SuperHeros.Add(superHeros);
            db.SaveChanges();
            
            return View(SuperHeros);
        }
        public ActionResult Delete(SuperHeros superHeros)
        {
            var SuperHeros = db.SuperHeros.Remove(superHeros);
            db.SaveChanges();
            return View(SuperHeros);
        }
        public ActionResult Edit(SuperHeros superHeros)
        {
            var SuperHeros = db.SuperHeros.Add(superHeros);
             db.SuperHeros.Remove(superHeros);
            db.SaveChanges();
            return View(SuperHeros);
        }
        public ActionResult Empty()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
    }
}