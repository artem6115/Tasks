using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebTasks.Data.DataLayer;

namespace WebTasks.Models
{
    public class MockDbAdapter : IDataBaseAdapter
    {
        public readonly TaskDbContext context;
        public MockDbAdapter(TaskDbContext context)=>this.context = context;
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

        Directory IDataBaseAdapter.AddTasks(Directory dir, IEnumerable<Tasks> tasks)
        {
            var CurrentDir = context.Directories.First(x => x.Id == dir.Id);
            if (CurrentDir == null) return null;
            foreach (var item in CurrentDir.MyTasks) CurrentDir.MyTasks.Add(item);
            context.SaveChanges ();
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

        Directory IDataBaseAdapter.DeleteDirectories(Directory dir)
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

        Directory IDataBaseAdapter.GetDirectories(int id)=>context.Directories.Include(x => x.MyTasks).First(x=>x.Id== id);

        Directory IDataBaseAdapter.ReplaceAllTasks(Directory dir, IEnumerable<Tasks> tasks)
        {
            var CurrentDir = context.Directories.First(x => x.Id == dir.Id);
            if (CurrentDir == null) return null;
            CurrentDir.MyTasks.Clear();
            foreach (var item in CurrentDir.MyTasks) CurrentDir.MyTasks.Add(item);
            context.SaveChanges();
            return CurrentDir;
        }
    }
}
