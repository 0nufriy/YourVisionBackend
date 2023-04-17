using Backend.Core.Models;

namespace Backend.Model
{
    public class SessionPost
    {
        public string Datetime { get; set; }
        public string Status { get; set; }
        public int DurationMinute { get; set; }
        public string Location { get; set; }
        public List<AudienceSessionDTO> Audiences { get; set; }
    }
}
