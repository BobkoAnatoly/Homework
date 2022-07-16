using Registration_program.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Registration_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                //db.Database.Migrate();
                var comp = new Competition() { Name = "Волат", Kind = CompetitionKind.Deadlift };
                var comp1 = new Competition() { Name = "Волат", Kind = CompetitionKind.Squat };
                var comp2 = new Competition() { Name = "Волат", Kind = CompetitionKind.Benchpress };

                db.Competitions.AddRangeAsync(comp, comp1, comp2);
                db.SaveChangesAsync();
            }
        }
    }
}
