using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PeopleOnMap.Models;

namespace PeopleOnMap.Controllers
{
    public class PeopleController : Controller
    {
        private ModelDB db1 = new ModelDB();

        // GET: People
        public ActionResult Index()
        {
            return View(db1.People.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db1.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,address,lat,lng,photo")] Person person)
        {
            if (ModelState.IsValid)
            {
                MapManager.SetCoord(person);
                db1.People.Add(person);
                db1.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db1.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,address,lat,lng,photo")] Person person)
        {
            if (ModelState.IsValid)
            {
                MapManager.SetCoord(person);
                db1.Entry(person).State = EntityState.Modified;
                db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db1.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db1.People.Find(id);
            db1.People.Remove(person);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db1.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
