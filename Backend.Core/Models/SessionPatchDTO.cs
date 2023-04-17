using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class SessionPatchDTO
    {
        public int SessionId { get; set; }
        public string Datetime { get; set; }
        public int? ProfileId { get; set; }
        public string Status { get; set; }
        public int DurationMinute { get; set; }
        public string Location { get; set; }
        public List<AudienceSessionDTO> Audiences { get; set; }
    }
}
