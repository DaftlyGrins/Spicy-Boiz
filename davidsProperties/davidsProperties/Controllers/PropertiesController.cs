using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using davidsProperties.Models;
using System.Threading.Tasks;

namespace davidsProperties.Controllers
{
    public class PropertiesController : Controller
    {
        private davidsPropertiesContext db = new davidsPropertiesContext();

        //// GET: Properties
        //public ActionResult Index()
        //{
        //    return View(db.Properties.ToList());
        //}        

        public async Task<ActionResult> Index(string searchString, int minRent = 0, int maxRent = 1500, bool rentCheck = false)
        {
            var properties = from p in db.Properties
                             select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                bool isPostcode = true;
                if (searchString.Length == 4)
                {
                    foreach (char c in searchString)
                    {
                        if (!Char.IsDigit(c))
                        {
                            isPostcode = false;
                        }
                    }
                }
                else
                {
                    isPostcode = false;
                }
                if (isPostcode)
                {
                    if (rentCheck)
                    {
                        properties = properties.Where(s => s.postcode.ToString().Equals(searchString) && s.rent >= minRent &&
                        s.rent <= maxRent);
                    } else
                    {
                        properties = properties.Where(s => s.postcode.ToString().Equals(searchString));
                    }
                    
                }
                else
                {
                    if (rentCheck)
                    {
                        properties = properties.Where(s => s.address.ToString().Contains(searchString) && s.rent >= minRent &&
                        s.rent <= maxRent);
                    } else
                    {
                        properties = properties.Where(s => s.address.ToString().Contains(searchString));
                    }
                    
                }

            }
            return View(await properties.ToListAsync());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,postcode,address,rent,image")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return Redirect("Index");
            }

            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,postcode,address,rent,image")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("~/Properties/Index");
            }
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return Redirect("~/Properties/Index");
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
