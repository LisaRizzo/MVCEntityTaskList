using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTaskListApp.Models;

namespace MVCTaskListApp.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task

        public ActionResult ViewTask()
        {
            using (DbTasks dbt = new DbTasks())
            {
                return View(dbt.TaskAccount.ToList());
            }
        }

        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(DoTask account)
        {
            if (ModelState.IsValid)
            {
                using (DbTasks dbt = new DbTasks())
                {
                    dbt.TaskAccount.Add(account);
                    dbt.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Succesfully added task.";
            }
            return View();
        }
    }
}