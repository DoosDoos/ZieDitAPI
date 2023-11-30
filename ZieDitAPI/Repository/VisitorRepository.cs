using ZieDitAPI.Data;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Models;

namespace ZieDitAPI.Repository
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly DataContext _context;

        public VisitorRepository(DataContext context)
        {
            _context = context;
        }
        public Visitor GetVisitor(int visitorId)
        {
            return _context.Visitors.Where(v => v.Id == visitorId).FirstOrDefault();
        }

        public ICollection<Visitor> GetVisitors()
        {
            return _context.Visitors.ToList();
        }

        public bool VisitorExists(int visitorId)
        {
            return _context.Visitors.Any(v => v.Id == visitorId);
        }
    }
}
