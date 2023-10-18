using DataLayer.Entities;
using System.Collections.Generic;

namespace WebTasks.Models
{
    public interface IDataBaseAdapter
    {
        Directory AddDirectory(Directory dir);
        Directory AddDirectory(string title);
        Directory AddTasks(Directory dir , IEnumerable<Tasks> tasks);
        Directory ReplaceAllTasks(Directory dir, IEnumerable<Tasks> tasks);
        Directory DeleteAllTasks(Directory dir);
        Directory DeleteDirectories(Directory dir);
        Directory DeleteDirectories(int id);
        Directory GetDirectories(int id);
        IEnumerable<Directory> GetAllDirectories();







    }
}
