using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTasks.Data.DataLayer;

namespace WebTasks.Models
{
    public class MockDbAdapter : IDataBaseAdapter
    {
        public readonly TaskDbContext context;
        public MockDbAdapter(TaskDbContext context)=>this.context = context;

        public Directory EditDirectoryTitle(Directory dir)
        {
            var directory = context.Directories.First(x=>x.Id== dir.Id);
            if (directory == null)
            {
                directory.Title = dir.Title;
                context.SaveChanges();
            }
            return directory;
        }

        Directory IDataBaseAdapter.AddDirectory(Directory dir) { 
            
            var directory = context.Directories.Add(dir).Entity;
            context.SaveChanges();
            return directory;
            }

        Directory IDataBaseAdapter.AddDirectory(string title)
        {
            var directory= context.Directories.Add(new Directory() { Title = title }).Entity;
            context.SaveChanges();
            return directory;

        }

        Directory IDataBaseAdapter.AddTask(Tasks task)
        {
            var CurrentDir = context.Directories.First(x => x.Id == task.Directory.Id);
            if (CurrentDir == null) return null;
            CurrentDir.MyTasks.Add(task);
            context.SaveChanges ();
            return CurrentDir;
        }
        Directory IDataBaseAdapter.EditTask(Tasks task)
        {
            var CurrentDir = context.Directories.First(x => x.Id == task.Directory.Id);
            var CurrentTask= context.Tasks.First(x => x.Id == task.Id);
            if (CurrentDir == null || CurrentTask == null) return null;
            CurrentTask.Title=task.Title;
            context.SaveChanges();
            return CurrentDir;
        }

        Directory IDataBaseAdapter.DeleteAllTasks(Directory dir)
        {
            var CurrentDir = context.Directories.First(x => x.Id == dir.Id);
            if (CurrentDir == null) return null;
            CurrentDir.MyTasks = null;
            context.SaveChanges();
            return CurrentDir;
        }

        Directory IDataBaseAdapter.DeleteDirectory(Directory dir)
        {
            var CurrentDir = context.Directories.First(x=>x.Id==dir.Id);
            if (CurrentDir == null) return null;
            context.Directories.Remove(CurrentDir);
            context.SaveChanges();
            return CurrentDir;
        }

        Directory IDataBaseAdapter.DeleteDirectories(int id)
        {
            var CurrentDir = context.Directories.First(x => x.Id == id);
            if (CurrentDir == null) return null;
            context.Directories.Remove(CurrentDir);
            context.SaveChanges();
            return CurrentDir;
        }

        IEnumerable<Directory> IDataBaseAdapter.GetAllDirectories() => context.Directories.Include(x=>x.MyTasks).ToList();

        Directory IDataBaseAdapter.GetDirectory(int id)=>context.Directories.Include(x => x.MyTasks).First(x=>x.Id== id);

        Directory IDataBaseAdapter.ReplaceAllTasks(Directory dir, IEnumerable<Tasks> tasks)
        {
            var CurrentDir = context.Directories.First(x => x.Id == dir.Id);
            if (CurrentDir == null) return null;
            CurrentDir.MyTasks.Clear();
            foreach (var item in CurrentDir.MyTasks) CurrentDir.MyTasks.Add(item);
            context.SaveChanges();
            return CurrentDir;
        }

        public Tasks GetTask(int id)=>context.Tasks.First(x=>x.Id == id);

        public Tasks DeleteTask(Tasks model)
        {
            var CurrentTask = context.Tasks.First(x => x.Id == model.Id);
            if (CurrentTask == null) return null;
            context.Remove(model);
            context.SaveChanges();
            return CurrentTask;
        }
    }
}
