namespace ZieDitAPI.Models
{
    public class Presenter
    {
        public int Id { get; set; }
        public string PresenterFirstName { get; set; }
        public string PresenterLastName { get; set; }
        public string PresenterEmail { get; set; }
        public Poster Posters { get; set; }
    }
}
