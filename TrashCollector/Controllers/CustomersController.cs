using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            string CurrentUserId = User.Identity.GetUserId(); //user thats logged in now
            Customers CurrentCustomerInfo = db.customers.Where(c => c.ApplicationUserID == CurrentUserId).FirstOrDefault();
            return RedirectToAction("Details", new { id = CurrentCustomerInfo.Id });
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Create"); 
            }
            else
            {
                string CurrentUserId = User.Identity.GetUserId(); //user thats logged in now
                Customers customer = db.customers.Find(id);
                customer.BillAmount = "$80";
                return View(customer); 
            }
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            //Create their account info address, start date
            Customers customer = new Customers();
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,City,State,ZipCode,StartPickUp,PickUpDate,StopPickUp,TempSuspendStart,TempSuspendEnd")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                // assign customer FK to aspnetuser!
                customers.ApplicationUserID = User.Identity.GetUserId();
                db.customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customers.Id });
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //if its returning me here then the id is null
                return View("Create");
            }
            Customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,City,State,ZipCode,StartPickUp,PickUpDate,StopPickUp,TempSuspendStart,TempSuspendEnd,OneTimePickUpDate")] Customers customers)
        {
            //find customer to edit and edit pick up date
            var customerToEdit = db.customers.Where(c => c.Id == customers.Id).FirstOrDefault();

            customerToEdit.ZipCode = customers.ZipCode;
            customerToEdit.StopPickUp = customers.StopPickUp;
            customerToEdit.StartPickUp = customers.StartPickUp;
            customerToEdit.PickUpdate = customers.PickUpdate; 
            customerToEdit.TempSuspendStart = customers.TempSuspendStart;
            customerToEdit.TempSuspendEnd = customers.TempSuspendEnd;
            customerToEdit.OneTimePickUpDate = customers.OneTimePickUpDate;
            customers.ApplicationUserID = User.Identity.GetUserId();
                //db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
            

            return RedirectToAction("Details", new { id = customers.Id });
        }



        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.customers.Find(id);
            db.customers.Remove(customers);
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
