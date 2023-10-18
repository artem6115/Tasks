using DataLayer.Entities;
using System.Collections.Generic;

namespace WebTasks.Models
{
    public interface IDataBaseAdapter
    {
        Directory AddDirectory(Directory dir);
        Directory AddDirectory(string title);
        Directory AddTask(Tasks task);
        Directory ReplaceAllTasks(Directory dir, IEnumerable<Tasks> tasks);
        Directory DeleteAllTasks(Directory dir);
        Directory DeleteDirectories(Directory dir);
        Directory DeleteDirectories(int id);
        Directory GetDirectory(int id);
        IEnumerable<Directory> GetAllDirectories();
        Directory EditDirectoryTitle(Directory dir);
        Directory EditTask(Tasks addMoedel);
        Tasks GetTask(int id);
    }
}
