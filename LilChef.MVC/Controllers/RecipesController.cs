using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LilChef.Data;
using LilChef.MVC.Data;

namespace LilChef.MVC.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Recipes
        public ActionResult Index()
        {
            return View(_db.Recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = _db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,RecipeName,Description,IngredientItems,Procedure,HasGluten,HasNuts,HasEggs,HasSoy,HasDairy,IsVegan,IsVegetarian,IsPescatarian,IsKetoFriendly,Difficulty")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _db.Recipes.Add(recipe);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = _db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeId,RecipeName,Description,IngredientItems,Procedure,HasGluten,HasNuts,HasEggs,HasSoy,HasDairy,IsVegan,IsVegetarian,IsPescatarian,IsKetoFriendly,Difficulty")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(recipe).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = _db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = _db.Recipes.Find(id);
            _db.Recipes.Remove(recipe);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
