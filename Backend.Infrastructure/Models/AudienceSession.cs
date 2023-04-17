using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class AudienceSession
    {
        public int SessionId { get; set; }
        public int AudiencePackId { get; set; }
        public int AudiencePackCount { get; set; }

        public AudiencePack AudiencePack { get; set; }
        public Session Session { get; set; }
    }
}
