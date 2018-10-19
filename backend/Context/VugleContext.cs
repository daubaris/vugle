using Microsoft.EntityFrameworkCore;
using VugleBE.Context.Models;

namespace VugleBE.Context
{
    public class VugleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VugleDB.db");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<PollResponse> PollResponses { get; set; }
    }
}