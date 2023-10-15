using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTasks.Data.DataLayer;
using WebTasks.Models;

namespace WebTasks.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IDataBaseAdapter _context;


        public HomeController(IDataBaseAdapter context,ILogger<HomeController> logger)
		{
			_context = context;
			_logger = logger;
		}

		public IActionResult Index()
		{

			return View(_context.GetAllDirectories());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
