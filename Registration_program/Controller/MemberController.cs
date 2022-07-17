using Microsoft.EntityFrameworkCore;
using Registration_program.Interfaces;
using Registration_program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration_program.Controller
{
    public class MemberController : IController
    {
        private ApplicationDbContext _context = null!;

        delegate void ActiontionHandler(string message);
        event ActiontionHandler? Deleted;
        event ActiontionHandler? Added;

        public MemberController()
        {
            Deleted += OnChange;
            Added += OnChange;
        }

        private void OnChange(string message)
        {
            Console.WriteLine(message);
        }
        public async Task Register(Member member, int competitionId)
        {
            using (_context = new ApplicationDbContext())
            {
                if (competitionId>=0)
                {
                    Competition? competition =await _context.Competitions.FindAsync(competitionId);
                    if (competition != null)
                    {
                        member.Competition = competition;
                        await _context.Members.AddAsync(member);
                        await _context.SaveChangesAsync();
                        Console.WriteLine("Участник зарегистрирован");
                        Task.WaitAll();
                    }
                } 
            }
        }

        public async Task Add<Member>(Member member)
        {
            if (member != null)
            {
                using (_context = new ApplicationDbContext())
                {
                    _context.Entry(member).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    Added?.Invoke("Участник добавлен в базу данных успешно");
                }
            }
        }

        public async Task Delete(int id)
        {
            using (_context = new ApplicationDbContext())
            {
                Member? member =await _context.Members.FindAsync(id);
                if (member != null)
                {
                    _context.Entry(member).State = EntityState.Deleted;
                    Deleted?.Invoke("Участник удалён");
                }
                await _context.SaveChangesAsync();
            }
        }

        public async void Show(int CompetitionId)
        {
            Thread.Sleep(200);
            using (_context = new ApplicationDbContext())
            {
                 Competition? competition =await _context.Competitions.FindAsync(CompetitionId);
                if (competition != null && (competition.Members?.Count > 0 && competition.Members != null))
                {
                    int i = 1;
                    Console.WriteLine($"Участники соревнования \"{competition.Name}\":");
                    foreach (var member in competition.Members)
                        Console.WriteLine($"{i++}. Id:{member.Id}. {member.FirstName} {member.LastName}.");
                }
                else
                    Console.WriteLine("Нету зарегистрированных участников");
            }
        }
    }
}
