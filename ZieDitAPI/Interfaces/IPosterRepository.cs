using ZieDitAPI.Models;

namespace ZieDitAPI.Interfaces
{
    public interface IPosterRepository
    {
        ICollection<Poster> GetPosters();
        Poster GetPoster(int id);
        ICollection<Presenter> GetPresenterOfAPoster(int posterId);
        bool PosterExists(int id);
        bool CreatePoster(Poster poster);
        bool UpdatePoster(Poster poster);
        bool DeletePoster(Poster poster);
        bool Save();
    }
}
