using LilChef.MVC.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        //Create new role
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}