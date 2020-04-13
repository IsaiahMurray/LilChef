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
    public class IngredientsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Ingredients
        public ActionResult Index()
        {
            return View(_db.Ingredients.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = _db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngredientId,IngredientName,Description,HasGluten,HasNuts,HasEggs,HasSoy,HasDairy,IsVegan,IsVegetarian,IsPescatarian,IsKetoFriendly,Category")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _db.Ingredients.Add(ingredient);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = _db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngredientId,IngredientName,Description,HasGluten,HasNuts,HasEggs,HasSoy,HasDairy,IsVegan,IsVegetarian,IsPescatarian,IsKetoFriendly,Category")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ingredient).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = _db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = _db.Ingredients.Find(id);
            _db.Ingredients.Remove(ingredient);
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
