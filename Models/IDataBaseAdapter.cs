using DataLayer.Entities;
using System.Collections.Generic;

namespace WebTasks.Models
{
    public interface IDataBaseAdapter
    {
        Directories AddDirectory(Directories dir);
        Directories AddDirectory(string title);
        Directories AddTasks(Directories dir , IEnumerable<Tasks> tasks);
        Directories ReplaceAllTasks(Directories dir, IEnumerable<Tasks> tasks);
        Directories DeleteAllTasks(Directories dir);
        Directories DeleteDirectories(Directories dir);
        Directories DeleteDirectories(int id);
        Directories GetDirectories(int id);
        IEnumerable<Directories> GetAllDirectories();







    }
}
