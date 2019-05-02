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
            return View(db.customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //redirect to create so the customer can create sign up to recieve trash pick up
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Create");

            }
            //var displayThatCustomerInfo = db.customers.Where(c => c.Id == id); dont think i need
            Customers customers = db.customers.Find(id);
            if (customers == null)
            {
                //redirect to create so the customer can create sign up to recieve trash pick up
                return HttpNotFound();
            }
            else
            {
                var displayThatCustomerInfo = db.customers.Where(c => c.Id == id);
                return View("Details");

            }
            //return View(displayThatCustomerInfo); dont think i need
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password,City,State,ZipCode")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,City,State,ZipCode,PickUpDate,StopPickUp")] Customers customers)
        {
            //find customer to edit and edit pick up date
            var customerToEdit = db.customers.Where(c => c.Id == customers.Id).FirstOrDefault();

            customerToEdit.PickUpdate = customers.PickUpdate;
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
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
