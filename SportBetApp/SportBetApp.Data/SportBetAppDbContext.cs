using SportBetApp.Data.Contracts;
using SportBetApp.Data.Models;
using System.Data.Entity;

namespace SportBetApp.Data
{
    public class SportBetAppDbContext : DbContext, ISportBetAppDbContext
    {
        public SportBetAppDbContext()
            : base("name=SportBetAppDbConnectionString")
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
