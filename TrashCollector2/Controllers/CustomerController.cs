﻿using Microsoft.AspNet.Identity;
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
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View();

        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,StreetAddress,Zipcode,pickupDay,balance,monthlyCharge,pickupConfirmed,Start,End")] Customer customer)
        {


            if (ModelState.IsValid)
            {

                //DateTime date1 = new DateTime(customer.Year,customer.Month,customer.Day);
                customer.ApplicationId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var editCustomer = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(editCustomer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,StreetAddress,City,State, Zipcode, pickupDay, pickupConfirmed,Start,End")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET: Customers/Edit/5
        public ActionResult ExtraPickup(int id)
        {
            var editCustomer = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(editCustomer);
        }
        [HttpPost]
        public ActionResult ExtraPickup(int id, Customer customer)
        {
            try
            {
                var editCustomer = db.Customers.Where(c => c.Id == id).FirstOrDefault();
                editCustomer.PickupDate = customer.PickupDate;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }
        public ActionResult Balance(int id)
        {
            var customerDetails = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customerDetails);
        }


}    }
