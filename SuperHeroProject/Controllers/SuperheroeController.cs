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
        public ActionResult Create([Bind( Include= "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphras")]SuperHeroes superHeros)
        {
            db.SuperHeros.Add(superHeros);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Hero = db.SuperHeros.Where(x => x.SuperHerosID == id);
            return View(Hero);
        }
        [HttpPost]
        public ActionResult Delete([Bind(Include = "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphras")]SuperHeroes superHeros, int id)
        {
            var deletedHeroe = db.SuperHeros.Where(x => x.SuperHeroID == id);
            db.SuperHeros.Remove(superHeros);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET: Superhero/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editSuperhero = db.SuperHeros.Where(x => x.SuperHeroID == id).First();
            return View(editSuperhero);
        }



        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID, SuperheroName,Alterego,PrimaryAbility,SecondaryAbility,Catchphrase")] SuperHeroes superhero)
        {
            var editSuperhero = db.SuperHeros.Where(s => superhero.SuperHeroID == superhero.SuperHeroID).FirstOrDefault();
            editSuperhero.Name = superhero.Name;
            editSuperhero.PrimaryPower = superhero.PrimaryPower;
            editSuperhero.SecondaryPower = superhero.SecondaryPower;
            editSuperhero.AlterEgo = superhero.AlterEgo;
            editSuperhero.Catchphrase = superhero.Catchphrase;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
       
       
        public ActionResult List([Bind(Include = "SuperHeroId,Name,PrimaryPower,SecondaryPower,AlterEgo,Catchphras")]SuperHeroes superHeros)
        {
           var listOfHeros = db.SuperHeros.ToList();
            return View(listOfHeros);
        }
    }
}