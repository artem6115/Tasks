﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Directory : Page
	{
		public List<Tasks> MyTasks{ get; set; }
	}
}
