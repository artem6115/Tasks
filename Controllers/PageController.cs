using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTasks.Models;
using WebTasks.Services;

namespace WebTasks.Controllers
{
    public class PageController : Controller
    {
        public readonly DirectoryService MyDirectoryService;
        public readonly TasksService MyTasksService;
        public readonly IDataBaseAdapter Context;

        public PageController(IDataBaseAdapter context,DirectoryService DirServ,TasksService TaskServ)
        {
            Context = context;
            MyDirectoryService= DirServ;
            MyTasksService = TaskServ;
        }
        public ActionResult Index()
        {
            return View(MyDirectoryService.GetAllDirectories());
        }
        public ActionResult Directory(int id)
        {
            return View(MyDirectoryService.GetDirectory(id));
        }
        public ActionResult Task(int id)
        {
            return View(MyTasksService.GetTask(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateDirectory(DirectoryEditModel model)
        {
            if(model!=null)
                MyDirectoryService.AddDirectory(model);
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditDirectory(DirectoryEditModel model)
        {
            if (model != null)
                MyDirectoryService.EditDirectory(model);
            return View();
            
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDirectory(DirectoryEditModel model)
        {
            if (model != null)
                MyDirectoryService.DeleteDirectory(model);
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateTask(TasksEditModel model)
        {
            if (model != null)
                MyTasksService.AddTask(model);
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask(TasksEditModel model)
        {
            if (model != null)
                MyTasksService.EditTask(model);
            return View();

        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTask(TasksEditModel model)
        {
            if (model != null)
                MyTasksService.DeleteTask(model);
            return View();

        }
    }
}
