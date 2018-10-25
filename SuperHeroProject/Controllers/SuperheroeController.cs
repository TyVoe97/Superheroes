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

        // GET: SuperHeros
        [HttpGet]
        public ActionResult Index()
        {
            var SuperHeros = db.SuperHeros.ToList();
            
            return View(SuperHeros);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SuperHeros newSuperHero = new SuperHeros();
            return View();
        }
       
        public ActionResult Create([Bind( Include= "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphras")]SuperHeros superHeros)
        {
            db.SuperHeros.Add(superHeros);
            db.SaveChanges();
            
            return View("Index");
        }
       
        public ActionResult Delete(SuperHeros superHeros)
        {
            db.SuperHeros.Remove(superHeros);
            db.SaveChanges();
            return View(SuperHeros);
        }
      
        public ActionResult Edit(SuperHeros superHeros)
        {
            db.SuperHeros.Add(superHeros);
             db.SuperHeros.Remove(superHeros);
            db.SaveChanges();
            return View(SuperHeros);
        }
       
        public ActionResult Empty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult List()
        {
            db.SuperHeros.ToList();
            return View();
        }
    }
}