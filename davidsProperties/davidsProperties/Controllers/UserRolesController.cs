﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using davidsProperties.Models;

namespace davidsProperties.Controllers
{
    public class UserRolesController : Controller
    {
        private userRolesContext db = new userRolesContext();

        public bool IsUserAdmin(string userEmail)
        {
            bool result = false;
            UserRoles user = db.UserRoles.Single(u => u.email == userEmail);
            if (user.userRole.Equals("Admin") || user.userRole.Equals("admin"))
            {
                result = true;
            }   
            return result;
        }

        // GET: UserRoles
        public ActionResult Index()
        {
            return View(db.UserRoles.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userRoles = db.UserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,email,userRole")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRoles);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userRoles = db.UserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,email,userRole")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRoles);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userRoles = db.UserRoles.Find(id);
            if (userRoles == null)
            {
                return HttpNotFound();
            }
            return View(userRoles);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRoles userRoles = db.UserRoles.Find(id);
            db.UserRoles.Remove(userRoles);
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
