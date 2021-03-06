﻿using Microsoft.AspNet.Identity;
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

        // GET: Employees
        public ActionResult Index()
        {
            return RedirectToAction("DayOfCustomerPickUp");
            //nativgate to the method above
        }

        public ActionResult DayOfCustomerPickUp()
        {
            string CurrentUserId = User.Identity.GetUserId(); //user ID thats logged in now
            var CurrentEmployee = db.employees.Where(e => e.ApplicationUserID == CurrentUserId).FirstOrDefault(); //comparing the user thats signed in ID to the ID in the database 
            List<Customers> CustomersZip = db.customers.Where(c => c.ZipCode == CurrentEmployee.ZipCode).ToList(); //&& PickedUp == false?
            //var CustomersZip = db.customers.Where(c => c.ZipCode == CurrentEmployee.ZipCode).ToList(); // compare the current employee thats logged in zip to the zips in the customer database and put it in a list

            string DayOfTheWeek = DateTime.Now.DayOfWeek.ToString().ToLower();//Time now look up this day of the week 
            var customersByZipAndDay = CustomersZip.Where(c => c.PickUpdate == DayOfTheWeek).ToList(); //comparing todays date to customers with todays pick up date
            return View("DayOfCustomerPickUp", customersByZipAndDay); //passes action to the view also zip and day filterd customers
        }

        public ActionResult TrashPickedUp(int id)
        {
            var CustomerPickedUp = db.customers.Where(c => c.Id == id).FirstOrDefault(); //comparing the user thats signed in ID to the ID in the database 
            var trashedPickedUp = CustomerPickedUp.PickedUp = true; //picked up trash
            CustomerPickedUp.BillAmount += 15; //add to bill
            db.SaveChanges();
            return RedirectToAction("DayOfCustomerPickUp");
        }

        // GET: Employees/Details/5
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
                return View(customer); //show the customers info then they can click to see details
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            //Create their account info zip
            Employees employee = new Employees();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ZipCode")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                // assign employees FK to aspnetuser!
                employees.ApplicationUserID = User.Identity.GetUserId();
                db.employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("DayOfCustomerPickUp");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //if its returning me here then the id is null
                return View("Create");
            }
            Employees employees = db.employees.Find(id);
            if(employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password,ZipCode")] Employees employees)
        {
            //find employee to edit 
            var employeeToEdit = db.employees.Where(e => e.Id == employees.Id).FirstOrDefault();

            employeeToEdit.FirstName = employees.FirstName;
            employeeToEdit.LastName = employees.LastName;
            employeeToEdit.ZipCode = employees.ZipCode;
            employees.ApplicationUserID = User.Identity.GetUserId();
            //db.Entry(employees).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Details", new { id = employees.Id }); 
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.employees.Find(id);
            db.employees.Remove(employees);
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
