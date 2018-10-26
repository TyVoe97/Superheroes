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
        public ActionResult Index()
        {
            List<SuperHeroes> superHeros = new List<SuperHeroes>();
            superHeros = db.SuperHeros.Select(x => x).ToList();
            
            return View(superHeros);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SuperHeroes newSuperHero = new SuperHeroes();
            return View(newSuperHero);
        }
        [HttpPost]
        public ActionResult Create([Bind( Include= "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphrase")]SuperHeroes superHeros)
        {
            db.SuperHeros.Add(superHeros);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Hero = db.SuperHeros.Where(x => x.SuperHeroID == id).Single();
            return View(Hero);
        }
        [HttpPost]
        public ActionResult Delete([Bind(Include = "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphrase")]SuperHeroes superHeros, int id)
        {
            var deletedHeroe = db.SuperHeros.Where(x => x.SuperHeroID == id).Single();
            db.SuperHeros.Remove(deletedHeroe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editSuperhero = db.SuperHeros.Where(x => x.SuperHeroID == id).Single();
            return View(editSuperhero);
        }



        [HttpPost]
        public ActionResult Edit([Bind(Include = "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphrase")]SuperHeroes superHeros)
        {
            var editSuperhero = db.SuperHeros.Where(s => superHeros.SuperHeroID == superHeros.SuperHeroID).Single();
            editSuperhero.Name = superHeros.Name;
            editSuperhero.PrimaryPower = superHeros.PrimaryPower;
            editSuperhero.SecondaryPower = superHeros.SecondaryPower;
            editSuperhero.AlterEgo = superHeros.AlterEgo;
            editSuperhero.Catchphrase = superHeros.Catchphrase;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
       
       
        public ActionResult List([Bind(Include = "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphrase")]SuperHeroes superHeros)
        {
           var listOfHeros = db.SuperHeros.ToList();
            return View(listOfHeros);
        }
    }
}