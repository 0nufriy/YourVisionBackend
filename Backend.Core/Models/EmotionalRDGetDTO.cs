using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class EmotionalRDGetDTO
    {
        public int AudienceId { get; set; }
        public int EmotionalResultId { get; set; }
        public string Emotional { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        
    }
}
