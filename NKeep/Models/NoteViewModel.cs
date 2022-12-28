namespace NKeep.Models
{
    public class NoteViewModel
    {
		public NoteViewModel(int id, string title, string text)
		{
			Id = id;
			Title = title;
			Text = text;
		}

		public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
    }
}
