using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Golazo.Models;

namespace Golazo.Controllers
{
   // [Authorize]
    public class SchedulerController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scheduler
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        // GET: Scheduler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduler scheduler = db.Schedulers.Find(id);
            if (scheduler == null)
            {
                return HttpNotFound();
            }
            return View(scheduler);
        }

        // GET: Scheduler/Create
        public ActionResult Create()
        {

            ViewBag.Teams = db.Teams.ToList();
            return View();
        }

        // POST: Scheduler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroundName,StartTime,EndTime,BookingDate,TeamId,PaidBy")] SchedulerViewModel schedulervm)
        {
            if (schedulervm.StartTime.TimeOfDay < schedulervm.EndTime.TimeOfDay)
            {
                if (ModelState.IsValid)
                {
                    var teamname = db.Teams.Where(x => x.ID == schedulervm.TeamId).FirstOrDefault().Name;
                    var scheduler = new Scheduler {
                        GroundName = schedulervm.GroundName,
                        StartTime = new DateTime(schedulervm.BookingDate.Year,
                                                    schedulervm.BookingDate.Month,
                                                    schedulervm.BookingDate.Day,
                                                    schedulervm.StartTime.Hour,
                                                    schedulervm.StartTime.Minute,
                                                    schedulervm.StartTime.Second),
                        EndTime = new DateTime(schedulervm.BookingDate.Year,
                                                    schedulervm.BookingDate.Month,
                                                    schedulervm.BookingDate.Day,
                                                    schedulervm.EndTime.Hour,
                                                    schedulervm.EndTime.Minute,
                                                    schedulervm.EndTime.Second),
                        TeamId = schedulervm.TeamId,

                        TeamName = teamname,
                        SelfPaid = !schedulervm.PaidBy.Equals("Team"),
                        PaidByTeam= schedulervm.PaidBy.Equals("Team")

                    };
                    db.Schedulers.Add(scheduler);
                    db.SaveChanges();
                    if (schedulervm.PaidBy.Equals("Team"))
                    {
                        var amount = 30.0;
                        SendEmailToTeam(schedulervm.TeamId, amount);

                    }
                   

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Teams = db.Teams.ToList();
                ModelState.AddModelError("EndTime", "End time should be greater thenstart time.");

            }
            return View(schedulervm); 
        }

        private void SendEmailToTeam(int teamId ,double amount)
        {
            var team_members = db.TeamMembers.Where(x => x.TeamId == teamId).ToList();
            if (team_members == null || team_members.Count == 0)
                return;
            var senderEmail = "golazofield@gmail.com";
            var senderPassword = "54jmP8.4HvZD_EF";
            SmtpClient client = new SmtpClient
            {
                Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword),
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true
            };

            amount /= team_members.Count();
            foreach (var item in team_members)
            {
                SendEmail(amount, senderEmail, client, item);

            }
        }

        private static void SendEmail(double amount, string senderEmail, SmtpClient client, TeamMember item)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail)
            };
            mailMessage.To.Add(new MailAddress(item.MemberEmail));
            mailMessage.Subject = "Booking";
            mailMessage.Body = $"you have to pay ${amount} for booking";
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            
            client.Send(mailMessage);
        }

        // GET: Scheduler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduler scheduler = db.Schedulers.Find(id);
            if (scheduler == null)
            {
                return HttpNotFound();
            }
            return View(scheduler);
        }

        // POST: Scheduler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroundName,StartTime,EndTime")] Scheduler scheduler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduler);
        }

        // GET: Scheduler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduler scheduler = db.Schedulers.Find(id);
            if (scheduler == null)
            {
                return HttpNotFound();
            }
            return View(scheduler);
        }

        // POST: Scheduler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scheduler scheduler = db.Schedulers.Find(id);
            db.Schedulers.Remove(scheduler);
            db.SaveChanges();
            return RedirectToAction("Index");
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
