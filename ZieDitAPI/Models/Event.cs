namespace ZieDitAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public ICollection<Poster> Posters { get; set; }
        public ICollection<Visitor> Visitors { get; set; }
    }
}
