using ZieDitAPI.Data;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Models;

namespace ZieDitAPI.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEvent(Event evenement)
        {
            _context.Add(evenement);
            return Save();
        }

        public bool DeleteEvent(Event evenement)
        {
            _context.Remove(evenement);
            return Save();
        }

        public bool EventExists(int eventId)
        {
            return _context.Events.Any(e => e.Id == eventId);
        }

        public Event GetEvent(int id)
        {
            return _context.Events.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Event> GetEvents()
        {
            return _context.Events.OrderBy(e => e.Id).ToList();
        }

        public ICollection<Poster> GetPosterByEvent(int eventId)
        {
            return _context.Posters.Where(e => e.Event.Id == eventId).ToList();
        }

        public ICollection<Visitor> GetVisitorByEvent(int eventId)
        {
            return _context.Visitors.Where(e => e.Event.Id == eventId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEvent(Event evenement)
        {
            _context.Update(evenement);
            return Save();
        }
    }
}
