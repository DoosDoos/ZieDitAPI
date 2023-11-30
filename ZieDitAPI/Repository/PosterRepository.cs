using AutoMapper;
using Microsoft.Extensions.Logging;
using ZieDitAPI.Data;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Models;

namespace ZieDitAPI.Repository
{
    public class PosterRepository : IPosterRepository
    {
        private DataContext _context;
        public PosterRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePoster(Poster poster)
        {
            _context.Add(poster);
            return Save();
        }

        public bool DeletePoster(Poster poster)
        {
            _context.Remove(poster);
            return Save();
        }

        public Poster GetPoster(int id)
        {
            return _context.Posters.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Poster> GetPosters()
        {
            return _context.Posters.ToList();
        }

        public ICollection<Presenter> GetPresenterOfAPoster(int posterId)
        {
            return _context.Presenters.Where(p => p.Posters.Id == posterId).ToList();
        }

        public bool PosterExists(int id)
        {
            return _context.Posters.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePoster(Poster poster)
        {
            _context.Update(poster);
            return Save();
        }
    }
}
