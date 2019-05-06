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

        // GET: Employees
        public ActionResult Index()
        {
            string CurrentUserId = User.Identity.GetUserId();
            var employee = db.employees.Where(c => c.ApplicationUserID == CurrentUserId).FirstOrDefault();
            List <Customers> sameZip = db.customers.Where(c => c.ZipCode == employee.ZipCode).ToList(); 
            //var CustomersSameZip = db.employees.Include(e => e.Customers).ToList();
            return View(sameZip);                                                                      
            //return View(db.customers.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //redirect to create so the employee can create their account
                //string CurrentUserId = User.Identity.GetUserId(); //user thats logged in now
                //customers = db.customers.Where(c => c.ApplicationUserID == CurrentUserId).FirstOrDefault();
                return View("Create"); 
            }
            else
            {
                string CurrentUserId = User.Identity.GetUserId(); //user thats logged in now
                Employees employee = db.employees.Find(id);
                return View(employee); //show the customers info then they can click to edit
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction("Details", new { id = employees.Id });
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
