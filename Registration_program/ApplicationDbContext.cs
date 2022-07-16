using Microsoft.EntityFrameworkCore;
using Registration_program.Models;
using System.IO;
using System.Threading.Tasks;

namespace Registration_program
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() => Database.EnsureCreated();

        public DbSet<Member> Members { get; set; } = null!;

        public DbSet<Competition> Competitions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = registration.db");
        }

    }
}
