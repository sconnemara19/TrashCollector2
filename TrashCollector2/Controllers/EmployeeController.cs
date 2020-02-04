using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var employeeDb = db.Employees.Where(e => e.ApplicationId == UserId).FirstOrDefault();
            var customerDb = db.Customers.Where(c => c.Zipcode == employeeDb.employeeZipcode && c.pickupDay == DateTime.Today.DayOfWeek).ToList();

            return View(customerDb);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employeeDetails = db.Employees.Where(d => d.employeeId == id).FirstOrDefault();

            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();
                employee.ApplicationId = id;
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeId,employeeZipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }





        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult WorkForToday()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DateTime.Today.DayOfWeek);

            return View(results);
        }
        public ActionResult WorkForSaturday()
        {

            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Saturday).ToList();

            return View(results);
        }
        public ActionResult WorkForSunday()
        {

            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Sunday).ToList();

            return View(results);
        }
        public ActionResult WorkForMonday()
        {

            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Monday).ToList();

            return View(results);
        }
        public ActionResult WorkForTuesday()
        {

            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Tuesday).ToList();

            return View(results);
        }
        public ActionResult WorkForWednesday()
        {

            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Wednesday).ToList();

            return View(results);
        }
        public ActionResult WorkForThursday()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Thursday).ToList();

            return View(results);


        }
        public ActionResult WorkForFriday()
        {

            var employeeId = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var results = db.Customers.Where(e => e.Zipcode == employee.employeeZipcode && e.pickupDay == DayOfWeek.Friday).ToList();

            return View(results);
        }
        public ActionResult PickupCharge(int id)
        {
            var charge = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View (charge);
        } 
        [HttpPost]
        public ActionResult ConfirmedPickupCharge(int id, Customer customer)
        {

            try
            {
                var charge = db.Customers.Where(c => c.Id == id).FirstOrDefault();
                charge.pickupConfirmed = customer.pickupConfirmed;
                charge.MonthlyCharge = customer.MonthlyCharge;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }



        }
        public ActionResult ScheduleForTheDay()
        {
            return View();
        }




    }

}



