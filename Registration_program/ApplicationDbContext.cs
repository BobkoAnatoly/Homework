using Microsoft.EntityFrameworkCore;
using Registration_program.Models;
using System.IO;

namespace Registration_program
{
    internal class ApplicationDbContext : DbContext
    {
        readonly StreamWriter logStream = new StreamWriter("log.txt",true);

        public ApplicationDbContext() { } /*=> Database.EnsureCreatedAsync();*/

        public DbSet<Member> Members { get; set; } = null!;

        public DbSet<Competition> Competitions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = registration.db");
            optionsBuilder.LogTo(logStream.WriteLine);
        }

    }
}
