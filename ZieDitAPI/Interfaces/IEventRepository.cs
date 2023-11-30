using ZieDitAPI.Models;

namespace ZieDitAPI.Interfaces
{
    public interface IEventRepository
    {
        ICollection<Event> GetEvents();
        Event GetEvent(int id);
        ICollection<Poster> GetPosterByEvent(int eventId);
        ICollection<Visitor> GetVisitorByEvent(int eventId);
        bool EventExists(int eventId);
        bool CreateEvent(Event evenement);
        bool UpdateEvent(Event evenement);
        bool DeleteEvent(Event evenement);
        bool Save();
    }
}
