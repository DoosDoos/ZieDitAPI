using ZieDitAPI.Models;

namespace ZieDitAPI.Interfaces
{
    public interface IVisitorRepository
    {
        ICollection<Visitor> GetVisitors();
        Visitor GetVisitor(int visitorId);
        bool VisitorExists(int visitorId);
    }
}
