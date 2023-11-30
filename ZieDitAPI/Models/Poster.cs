namespace ZieDitAPI.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public string PosterImagePath { get; set; }
        public int ReceivedCredits { get; set; }
        public ICollection<Presenter> Presenters { get; set; }
        public Event Event { get; set; }
    }
}
