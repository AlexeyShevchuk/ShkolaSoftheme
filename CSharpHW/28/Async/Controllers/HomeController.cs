using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Async.Models;

namespace Async.Controllers
{
    public class HomeController : Controller
    {
        private StudentsDbContext db = new StudentsDbContext();



        public async Task<ActionResult> Index()
        {
            var students = await db.Students.ToListAsync();
            var curators = await db.Curators.ToListAsync();
            var groups = await db.Groups.ToListAsync();
            ViewBag.Students = students;
            ViewBag.Curators = curators;
            ViewBag.Groups = groups;
            return View();
        }

        [HttpPost]
        public async Task<string> AddCurator(Curator curator)
        {
            await Task.Run(() =>
            {
                db.Curators.Add(curator);
                db.SaveChanges();
            });
            return "New Curator Added " + curator.CuratorId + " " + curator.FullName;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}