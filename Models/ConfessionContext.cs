using Microsoft.EntityFrameworkCore;

namespace eating_confessions.Models
{
    public class ConfessionContext : DbContext
    {
        public ConfessionContext(DbContextOptions<ConfessionContext> options) : base(options)
        {

        }

        public DbSet<Confession> Confessions {get; set;}
    }
}