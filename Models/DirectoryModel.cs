using DataLayer.Entities;
using System.Collections.Generic;

namespace WebTasks.Models
{
    public class DirectoryViewModel: PageViewModel
    {
        public Directory Directory { get; set; }
        public List<Tasks> Tasks { get; set; }

    }
    public class DirectoryEditModel : PageEditModel
    {
       // public int DirectoryId { get; set; }
    }
}
