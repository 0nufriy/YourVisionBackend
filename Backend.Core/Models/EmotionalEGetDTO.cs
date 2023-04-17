using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class EmotionalEGetDTO
    {
        public int AudienceId { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public List<EmotionalEDGetDTO> EmotionalEDGetDTO { get; set; }
       
        
    }
}
