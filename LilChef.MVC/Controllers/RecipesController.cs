﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using LilChef.Data;
using LilChef.MVC.Data;
using Microsoft.AspNet.Identity;

namespace LilChef.MVC.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public string GetEmailAdress()
        {
            var userId = User.Identity.GetUserId();
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            return user.Email;
        }

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
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Recipe recipe)
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
        [Authorize]
        public ActionResult Edit(int? id)
        {
            Recipe recipe = _db.Recipes.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);

        }

        // POST: Recipes/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Recipe recipe)
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
        [Authorize]
        public ActionResult Delete(int? id)
        {
            Recipe recipe = _db.Recipes.Find(id);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (recipe == null)
                {
                    return HttpNotFound();
                }
                return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
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
