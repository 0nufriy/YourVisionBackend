using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class AudiencePack
    {
        public int AudiencePackId { get; set; }
        public string AudiencePackName { get; set; }
        public int Price { get; set; }

        public List<AAP> AAPs { get; set; }
        public List<AudienceSession> AudienceSession { get; set; }
    }
}
