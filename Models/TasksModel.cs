using DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace WebTasks.Models
{
    public class TasksViewModel:PageViewModel
    {
        public Tasks Taks { get; set; }       
    }
    public class TasksEditModel : PageEditModel
    {
        [Required]
        public int DirectoryId { get; set; }
    }
}
