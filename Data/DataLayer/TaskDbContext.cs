using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebTasks.Data.DataLayer
{
	public class TaskDbContext :DbContext
	{
		public TaskDbContext(DbContextOptions<TaskDbContext>options):base(options){}
		public DbSet<Directory> Directories { get; set; }
		public DbSet<Tasks> Tasks { get; set; }

	}
	
}
