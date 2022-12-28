using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NKeep.Areas.Identity.Data;
using NKeep.Data;
using NKeep.Models;
using System.Diagnostics;

namespace NKeep.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private ApplicationContext _db;
		private UserManager<User> _userManager;

		public HomeController(ILogger<HomeController> logger, ApplicationContext db, UserManager<User> userManager)
		{
			_logger = logger;
			_db = db;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var id = _userManager.GetUserId(User);
				List<Note> notes = _db.Notes.Where(note => note.UserId == id).ToList();
				return View(notes);
			}
			return View();
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