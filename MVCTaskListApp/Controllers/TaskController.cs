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
        private DbTasks dbt = new DbTasks();
        [HttpGet]
        public ActionResult ViewTask()
        {
            return View(dbt.TaskAccount.ToList());
        }

        [HttpPost]
        public ActionResult DeleteTask(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                using (DbTasks dbt = new DbTasks())
                {
                    string[] ids = formCollection["taskIdDelete"].Split(new char[] { ',' });
                    foreach (string id in ids)
                    {
                        var task = dbt.TaskAccount.Find(int.Parse(id));
                        dbt.TaskAccount.Remove(task);
                        dbt.SaveChanges();
                    }
                }
            }

            return RedirectToAction("ViewTask");
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