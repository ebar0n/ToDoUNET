using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext dbTask = new TaskContext();
        private UsersContext dbUser = new UsersContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";
            ViewBag.numTask = dbTask.TaskModels.ToList().Count();
            ViewBag.numUser = dbUser.UserProfiles.ToList().Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

    }
}
