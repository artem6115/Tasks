using System.ComponentModel.DataAnnotations;

namespace WebTasks.Models
{
    public abstract class PageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
    public abstract class PageEditModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
