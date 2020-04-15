using LilChef.MVC.Data;
using LilChef.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LilChef.MVC.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _context;
        public RoleController()
        {
           _context = new ApplicationDbContext();
        }
        //Get all roles
        [Authorize(Roles = "Lord")]
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        //Create new role
        [Authorize(Roles = "Lord")]
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        [Authorize(Roles = "Lord")]
        public ActionResult Create(IdentityRole role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(IdentityRole role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}