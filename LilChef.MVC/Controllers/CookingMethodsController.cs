using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LilChef.Data;
using LilChef.MVC.Data;

namespace LilChef.MVC.Controllers
{
    public class CookingMethodsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: CookingMethods
        //public ActionResult Index()
        //{
        //    return View(_db.CookingMethods.ToList());
        //}

        //GET: sort
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DifficultySortParm"] = sortOrder == "Difficulty" ? "difficulty_desc" : "Difficulty";
            var methods = from model in _db.CookingMethods
                           select model;
            switch (sortOrder)
            {
                case "name_desc":
                    methods = methods.OrderByDescending(model => model.CookingMethodName);
                    break;
                case "Difficulty":
                    methods = methods.OrderBy(model => model.Difficulty);
                    break;
                case "difficulty_desc":
                    methods = methods.OrderByDescending(model => model.Difficulty);
                    break;
                default:
                    methods = methods.OrderBy(model => model.CookingMethodName);
                    break;
            }
            return View(await methods.AsNoTracking().ToListAsync());
        }

        // GET: CookingMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookingMethod cookingMethod = _db.CookingMethods.Find(id);
            if (cookingMethod == null)
            {
                return HttpNotFound();
            }
            return View(cookingMethod);
        }

        // GET: CookingMethods/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CookingMethods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "CookingMethodId,CookingMethodName,Description,Difficulty")] CookingMethod cookingMethod)
        {
            if (ModelState.IsValid)
            {
                _db.CookingMethods.Add(cookingMethod);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cookingMethod);
        }

        // GET: CookingMethods/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookingMethod cookingMethod = _db.CookingMethods.Find(id);
            if (cookingMethod == null)
            {
                return HttpNotFound();
            }
            return View(cookingMethod);
        }

        // POST: CookingMethods/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "CookingMethodId,CookingMethodName,Description,Difficulty")] CookingMethod cookingMethod)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(cookingMethod).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cookingMethod);
        }

        // GET: CookingMethods/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookingMethod cookingMethod = _db.CookingMethods.Find(id);
            if (cookingMethod == null)
            {
                return HttpNotFound();
            }
            return View(cookingMethod);
        }

        // POST: CookingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            CookingMethod cookingMethod = _db.CookingMethods.Find(id);
            _db.CookingMethods.Remove(cookingMethod);
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
