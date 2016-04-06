using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private TaskContext db = new TaskContext();

        //
        // GET: /Task/

        public ActionResult Index()
        {
            return View(db.TaskModels.ToList());
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id = 0)
        {
            TaskModels taskmodels = db.TaskModels.Find(id);
            if (taskmodels == null)
            {
                return HttpNotFound();
            }
            return View(taskmodels);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(TaskModels taskmodels)
        {
            if (ModelState.IsValid)
            {
                db.TaskModels.Add(taskmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskmodels);
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TaskModels taskmodels = db.TaskModels.Find(id);
            if (taskmodels == null)
            {
                return HttpNotFound();
            }
            return View(taskmodels);
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(TaskModels taskmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskmodels);
        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TaskModels taskmodels = db.TaskModels.Find(id);
            if (taskmodels == null)
            {
                return HttpNotFound();
            }
            return View(taskmodels);
        }

        //
        // POST: /Task/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskModels taskmodels = db.TaskModels.Find(id);
            db.TaskModels.Remove(taskmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}