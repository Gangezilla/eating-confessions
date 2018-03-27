using Microsoft.EntityFrameworkCore;

namespace eating_confessions.Models
{
    public class ConfessionContext : DbContext
    {
        public ConfessionContext(DbContextOptions<ConfessionContext> options) : base(options)
        {

        }

        public DbSet<ConfessionItem> ConfessionItems {get; set;}
    }
}

// using Microsoft.EntityFrameworkCore;

// namespace TodoApi.Models
// {
//     public class TodoContext : DbContext
//     {
//         public TodoContext(DbContextOptions<TodoContext> options)
//             : base(options)
//         {
//         }

//         public DbSet<TodoItem> TodoItems { get; set; }

//     }
// }