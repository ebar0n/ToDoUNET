using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;
using WebMatrix.WebData;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private TaskContext db = new TaskContext();

        //
        // GET: /Task/
        [Authorize]
        public ActionResult Index()
        {
            int UserId = WebSecurity.GetUserId(User.Identity.Name);
            return View(db.TaskModels.Where(Task => Task.UserId==UserId).ToList());
        }

        //
        // GET: /Task/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create(TaskModels taskmodels)
        {
            taskmodels.UserId = WebSecurity.GetUserId(User.Identity.Name);
            taskmodels.CreatedAt = DateTime.Now;
            taskmodels.UpdatedAt = DateTime.Now;
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
        [Authorize]
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
                taskmodels.UpdatedAt = DateTime.Now;
                taskmodels.UserId = WebSecurity.GetUserId(User.Identity.Name);
                db.Entry(taskmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskmodels);
        }

        //
        // GET: /Task/Delete/5
        [Authorize]
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
        [Authorize]
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