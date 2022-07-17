using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_program.Models
{
    public enum CompetitionKind
    {
        Deadlift,
        Benchpress,
        Squat
    }
    public class Competition
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public CompetitionKind Kind { get; set; }

        public ICollection<Member>? Members { get; set; }
    }
}
