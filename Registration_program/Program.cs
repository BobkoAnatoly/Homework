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
            CompetitionController competitionController = new CompetitionController();
            //competitionController.Add(competition);
            Member member = new Member() { FirstName = "Димитрй", LastName = "Коршунов",Age = 12};
            competitionController.Show();
        }
    }
}
