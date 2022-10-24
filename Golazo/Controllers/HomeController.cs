using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Golazo.Models;
using System.Net;
using System.Data.Entity;
using System.Web.Security;


namespace Golazo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "What is the website about.";

            ViewBag.Message = "The website I created is designed for people looking to book a soccer field to play at, the website connects all of the soccer fields in Kuwait. Each Team created on" +
           " the website has a minimum requirement of 14 people and every person must fill out their information and create an account that asks for their" +
            "details, after that they choose a team to join, or they can create a team.If they choose to join an existing team, they will be asked to provide an ID number that was given" +
            "to them by the Admin of the team.If the person decides to create a team, he must invite 14 people to join his team and after the 14 individuals create their accounts using" +
           "the invitation link, the team will be formed.After the team is formed, a schedule will appear that will display the available time slots for every soccer field in Kuwait," +
          "the individual can choose which soccer field they prefer, the date, and the time they would like to reserve it.After choosing everything, the team members will receive" +
          "notifications 48 hours before the booking time stating that the team admin has scheduled a game for the team, and you can choose to reserve your place on the team and" +
          "participate(in case the team has more than 14 participants).After the roster is filled, the participating players will receive an invoice via links distributed" +
          "through the website so they can fulfill their payments and complete their reservation, so the availability is removed from the website.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Name,PhoneNo,Message")] ContactUs contact)
        {

            if (ModelState.IsValid)
            {


                db.ContactUs.Add(contact);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(contact);
        }


        public JsonResult GetEvents()
        {
            var _context = new ApplicationDbContext();
            var today = DateTime.Now;
            var StartDate = new DateTime(today.Year, today.Month - 1, 1);
            var events = _context.Schedulers.Where(x => x.StartTime >= StartDate).ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}