using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;
using ZieDitAPI.Models;

namespace ZieDitAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<Presenter> Presenters { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
