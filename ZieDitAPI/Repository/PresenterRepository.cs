using AutoMapper;
using Microsoft.Extensions.Logging;
using ZieDitAPI.Data;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Models;

namespace ZieDitAPI.Repository
{
    public class PresenterRepository : IPresenterRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PresenterRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreatePresenter(Presenter presenter)
        {
            _context.Add(presenter);
            return Save();
        }

        public bool DeletePresenter(Presenter presenter)
        {
            _context.Remove(presenter);
            return Save();
        }

        public Presenter GetPresenter(int id)
        {
            return _context.Presenters.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Presenter> GetPresenters()
        {
            return _context.Presenters.ToList();
        }

        public bool PresenterExists(int id)
        {
            return _context.Presenters.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePresenter(Presenter presenter)
        {
            _context.Update(presenter);
            return Save();
        }
    }
}
