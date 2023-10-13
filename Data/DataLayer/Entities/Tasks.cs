using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Tasks : Page
	{
		public int IdDirectory { get; set; }
		public Directories Directory { get; set; }
	}
}
