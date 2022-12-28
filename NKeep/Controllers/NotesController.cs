using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NKeep.Areas.Identity.Data;
using NKeep.Data;
using NKeep.Models;

namespace NKeep.Controllers
{
    public class NotesController : Controller
    {
        private ApplicationContext _db;
        private UserManager<User> _userManager;
        public IActionResult Index()
        {
            return View();
        }
        public NotesController(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote(string Title, string Text)
        {
            
            if (Title != "" && Text != "")
            {
                var id = _userManager.GetUserId(User);
                var user = _db.Users.FirstOrDefault(u => u.Id == id);
                Note note = new Note
                {
                    Title = Title,
                    Text = Text,
                    CreationDate = DateTime.Now,
                    LastModifiedTime = DateTime.Now,
                    User = user
            };
                _db.Notes.Add(note);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
		[HttpPost]
		public async Task<IActionResult> EditNote(int id, string Title, string Text)
		{

			if (Title != "" && Text != "")
			{
                Note note = _db.Notes.Where(u => u.Id == id).FirstOrDefault();
                note.Title = Title;
                note.Text = Text;
                note.LastModifiedTime = DateTime.Now;
				_db.SaveChanges();
			}

			return RedirectToAction("Index", "Home");
		}
        public IActionResult EditNote(int id)
        {
            Note note = _db.Notes.Where(u => u.Id == id).FirstOrDefault();
            NoteViewModel nvm = new NoteViewModel(note.Id, note.Title, note.Text);
            return View(nvm);
        }
	}
}
