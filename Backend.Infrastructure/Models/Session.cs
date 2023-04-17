using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Datetime { get; set; }
        public int? ProfileId { get; set; }
        public string Status { get; set; }
        public int DurationMinute { get; set; }
        public string Location { get; set; }
        public Profile Profile { get; set; }

        public List<AudienceSession> AudienceSession { get; set; }
        public List<EmotionalExpect> EmotionalExpect { get; set;}
        public List<EmotionalResult> EmotionalResult { get; set;}
        public Report Report { get; set; }
    }
}
