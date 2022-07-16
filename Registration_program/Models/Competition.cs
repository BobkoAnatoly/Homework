using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_program.Models
{
    public class Competition
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public CompetitionKind Kind { get; set; }

        public ICollection<Member>? Members { get; set; }
    }
}
