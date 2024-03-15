using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList

        ToDoListContext _db=new ToDoListContext();
        public ActionResult Index()
        {
            var data = _db.ToDoLists.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoList todolist)
        {

            if (_db.ToDoLists.Where(model => model.Task == todolist.Task && model.IsCompleted == false).ToList().Count > 0)
            {
                TempData["InsertMessage"] = "Task with same name already exists!!";
                return RedirectToAction("Index");
            }
             else if (ModelState.IsValid)
            {
                _db.ToDoLists.Add(todolist);
                _db.SaveChanges();
                TempData["success"] = "Task Created Successfully";
                return RedirectToAction("Index");
            }
            return View();



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {


            if (id == null || id == 0)
            {

                return RedirectToAction("Index", "ToDoList");
            }
            ToDoList TaskFromDb = _db.ToDoLists.Find(id);
            _db.ToDoLists.Remove(TaskFromDb);
            _db.SaveChanges();
            TempData["success"] = "Task Deleted Successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Completed(int? id)
        {
            ToDoList TaskFromDb = _db.ToDoLists.Find(id);

            if (TaskFromDb.IsCompleted == false)
            {
                TaskFromDb.IsCompleted = true;
            }
           


            _db.ToDoLists.AddOrUpdate(TaskFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      
  

    }
}