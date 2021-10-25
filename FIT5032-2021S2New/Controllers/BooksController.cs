using FIT5032_2021S2New.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_2021S2New.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookEvents
        public ActionResult Index()
        {
            return HttpNotFound();
        }

        [Authorize(Roles = "Customer")] 
        public ActionResult ViewBookedEvents()
        {
            var userId = User.Identity.GetUserId();
            return View(db.Books.Include("Event").Include("Event.Event_Type").Include("Event.Store").Where(be => be.UserId == userId).ToList());
        }

        [Authorize(Roles = "Customer")]
        public ActionResult DeleteBookEvent(int storeEventId)
        {
            var userId = User.Identity.GetUserId();
            var deleteEvent = db.Books.FirstOrDefault(be => be.Event_id == storeEventId && be.UserId == userId);
            if (deleteEvent != null)
            {
                db.Books.Remove(deleteEvent);
                db.SaveChanges();
            }
            return RedirectToAction("ViewBookedEvents");
        }

        [Authorize(Roles = "Customer")]
        public ActionResult BookEvent(int id)
        {

            try
            {
                // find user
                var userId = User.Identity.GetUserId();

                // add bookevent to db
                var bookEvent = new BookEvent { Event_id = id, UserId = userId };
                db.Books.Add(bookEvent);
                db.SaveChanges();

                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                bookEvent.Event = db.Events.FirstOrDefault(se => se.Event_id == id);
                bookEvent.Event.Store = db.Stores.FirstOrDefault(s => s.Store_id == bookEvent.Event.Store_id);

                // send email
                //String toEmail = user.Email;
                //String subject = "Book event comfirmation";
                //String contents = $"Store: {bookEvent.Event.Store.Store_name}, start time: {bookEvent.Event.Start_time.ToString("dd-MMM-yyyy mm:HH")}";

                //EmailSender es = new EmailSender();
                //es.Send(toEmail, subject, contents);

                //ViewBag.Result = "Email has been send.";

                return RedirectToAction("ViewBookedEvents");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return RedirectToAction("ViewBookedEvents");
            }
        }
    }
}