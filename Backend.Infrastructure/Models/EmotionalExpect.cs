using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class EmotionalExpect
    {
        public int EmotionalExpectId { get; set; }
        public int SessionId { get; set; }
        public string Emotional { get; set; }
        public int AudienceId { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Audience Audience { get; set; }
        public Session Session { get; set; }
    }
}
