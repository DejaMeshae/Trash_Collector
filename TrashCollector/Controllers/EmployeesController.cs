using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
                private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            string CurrentUserId = User.Identity.GetUserId();
            //var customersSameZip = db.employees.Include(e => e.FK.ToList(); FK for foriegn key once i figure that out
            var CustomersSameZip = db.employees.Include(e => e.Customers).ToList();
            return View(CustomersSameZip);                                                                      
            //return View(db.customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                Customers customers = null;
                //redirect to create so the customer can create sign up to recieve trash pick up
                string CurrentUserId = User.Identity.GetUserId(); //user thats logged in now
                //customers = db.customers.Where(c => c.ApplicationUserID == CurrentUserId).FirstOrDefault();
                return View(customers); //show the customers info then they can click to edit
            }
            //var displayThatCustomerInfo = db.customers.Where(c => c.Id == id); dont think i need
            //Customers customers = db.customers.Find(id);
            //if (customers == null)
            //{
            //    //redirect to create so the customer can create sign up to recieve trash pick up
            //    return HttpNotFound();
            //}
            //else
            //{

            return View(); //show the customers info then they can click to edit

            //}
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,City,State,ZipCode,PickUpDate,StopPickUp,TempSuspendStart,TempSuspendEnd")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                // assign customer FK to aspnetuser!
                customers.ApplicationUserID = User.Identity.GetUserId();
                customers.Password = "password"; //might not need this line
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,City,State,ZipCode,PickUpDate,StopPickUp,TempSuspendStart,TempSuspendEnd")] Customers customers)
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
        //hi
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
