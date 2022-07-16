using Registration_program.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Registration_program.Controller;

namespace Registration_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Competition competition = new Competition() { Name = "WRPF", Kind = CompetitionKind.Deadlift };
            CompetitionController competitionController = new CompetitionController();
            //competitionController.Add(competition);
            competitionController.Delete(14);
            competitionController.Show();
        }
    }
}
