using Microsoft.EntityFrameworkCore;

namespace Task1.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
    }
}
