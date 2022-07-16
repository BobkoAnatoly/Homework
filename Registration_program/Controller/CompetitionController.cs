using Microsoft.EntityFrameworkCore;
using Registration_program.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Registration_program.Models;

namespace Registration_program.Controller
{
    public class CompetitionController : IController
    {
        private ApplicationDbContext _context = null!;

        delegate void ActiontionHandler(string message);
        event ActiontionHandler? Deleted;
        event ActiontionHandler? Added;


        public CompetitionController()
        {
            Deleted += OnDelete;
            Added += OnAdd;
        }

        private void OnDelete(string message)
        {
            Console.WriteLine(message);
        }
        private void OnAdd(string message)
        {
            Console.WriteLine(message);
        }

        public async Task Add<Competition>(Competition? competition)
        {
            if (competition != null)
            {
                using (_context = new ApplicationDbContext())
                {
                    _context.Entry(competition).State = EntityState.Added;
                    await _context.SaveChangesAsync();
                    Added?.Invoke("Соревнование добавлено успешно.");
                }
            }
        }

        public async Task Add<Competition>(IEnumerable<Competition> competitions)
        {
            using (_context = new ApplicationDbContext())
            {
                foreach (Competition? item in competitions)
                {
                    if (item != null)
                        _context.Entry(item).State = EntityState.Added;
                    continue;
                }
                await _context.SaveChangesAsync();
                Added?.Invoke("Соревнования добавлены успешно.");
                Task.WaitAll();
            }
        }

        public async Task Delete(int id)
        {
            using (_context = new ApplicationDbContext())
            {
                Competition? competition =await _context.Competitions.FindAsync(id);
                if (competition != null)
                {
                    _context.Entry(competition).State = EntityState.Deleted;
                    Deleted?.Invoke("Соревнование удалено");
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task Show()
        {
            using (_context = new ApplicationDbContext())
            {
                int i = 1;
                foreach (var item in await _context.Competitions.ToListAsync())
                {
                    Console.WriteLine($"{i++}.Id {item.Id}. {item.Name} - {item.Kind}");
                }
            }
        }
        public async void ShowMenbers(int id)
        {
            using (_context = new ApplicationDbContext())
            {
                Competition? competition =await _context.Competitions.FindAsync(id);
                if (competition != null && competition.Members != null)
                {
                    foreach (var item in competition.Members)
                    {
                        Console.WriteLine($"{item.Id}. {item.FirstName} {item.LastName}.");
                    }
                }
            }
        }
    }
}
