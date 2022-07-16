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

        delegate void CompetitionHandler(string message);
        private event CompetitionHandler? Deleted;
        private event CompetitionHandler? Added;


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

        public void Add<Competition>(Competition? competition)
        {
            if (competition != null)
            {
                using (_context = new ApplicationDbContext())
                {
                    _context.Entry(competition).State = EntityState.Added;
                    _context.SaveChanges();
                    Added?.Invoke("Соревнование добавлено успешно.");
                }
            }
        }

        public void Add<Competition>(IEnumerable<Competition> competitions)
        {
            using (_context = new ApplicationDbContext())
            {
                foreach (Competition? item in competitions)
                {
                    if (item != null)
                        _context.Entry(item).State = EntityState.Added;
                    continue;
                }
                _context.SaveChanges();
                Added?.Invoke("Соревнования добавлены успешно.");
                Task.WaitAll();
            }
        }

        public void Delete(int id)
        {
            using (_context = new ApplicationDbContext())
            {
                Competition competition =_context.Competitions.Find(id)!;
                if (competition != null)
                {
                    _context.Entry(competition).State = EntityState.Deleted;
                    Deleted?.Invoke("Соревнование удалено");
                }
                _context.SaveChanges();
            }
            return;
        }

        public void Show()
        {
            using (_context = new ApplicationDbContext())
            {
                foreach (var item in _context.Competitions.ToList())
                {
                    Console.WriteLine($"{item.Id}. {item.Name} - {item.Kind}");
                }
            }
        }
        public void ShowMenbers(int id)
        {
            using (_context = new ApplicationDbContext())
            {
                Competition competition = _context.Competitions.Find(id)!;
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
