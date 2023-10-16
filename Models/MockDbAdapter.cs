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
        Directories IDataBaseAdapter.AddDirectory(Directories dir) { 
            
            var directory = context.Directories.Add(dir).Entity;
            context.SaveChanges();
            return directory;
            }

        Directories IDataBaseAdapter.AddDirectory(string title)
        {
            var directory= context.Directories.Add(new Directories() { Title = title }).Entity;
            context.SaveChanges();
            return directory;

        }

        Directories IDataBaseAdapter.AddTasks(Directories dir, IEnumerable<Tasks> tasks)
        {
            var CurrentDir = context.Directories.First(x => x.Id == dir.Id);
            if (CurrentDir == null) return null;
            foreach (var item in CurrentDir.MyTasks) CurrentDir.MyTasks.Add(item);
            context.SaveChanges ();
            return CurrentDir;


        }

        Directories IDataBaseAdapter.DeleteAllTasks(Directories dir)
        {
            var CurrentDir = context.Directories.First(x => x.Id == dir.Id);
            if (CurrentDir == null) return null;
            CurrentDir.MyTasks = null;
            context.SaveChanges();
            return CurrentDir;
        }

        Directories IDataBaseAdapter.DeleteDirectories(Directories dir)
        {
            var CurrentDir = context.Directories.First(x=>x.Id==dir.Id);
            if (CurrentDir == null) return null;
            context.Directories.Remove(CurrentDir);
            context.SaveChanges();
            return CurrentDir;
        }

        Directories IDataBaseAdapter.DeleteDirectories(int id)
        {
            var CurrentDir = context.Directories.First(x => x.Id == id);
            if (CurrentDir == null) return null;
            context.Directories.Remove(CurrentDir);
            context.SaveChanges();
            return CurrentDir;
        }

        IEnumerable<Directories> IDataBaseAdapter.GetAllDirectories() => context.Directories.Include(x=>x.MyTasks).ToList();

        Directories IDataBaseAdapter.GetDirectories(int id)=>context.Directories.Include(x => x.MyTasks).First(x=>x.Id== id);

        Directories IDataBaseAdapter.ReplaceAllTasks(Directories dir, IEnumerable<Tasks> tasks)
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
