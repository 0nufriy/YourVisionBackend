using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class EmotionalGetDTO
    {
        public List<EmotionalRGetDTO>? EmotionalResult { get; set; }
        public List<EmotionalEGetDTO>? EmotionalExpect { get; set; }
    }
}
