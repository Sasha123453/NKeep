
using NKeep.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace NKeep.Models
{
	public class Note
	{
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public string Text { get; set; } = "";

		[Column(TypeName = "Date")]
		public DateTime CreationDate { get; set; }
		[Column(TypeName = "Date")]
		public DateTime LastModifiedTime { get; set; }
		public string  UserId { get; set; }
		public User User { get; set; }
	}
}