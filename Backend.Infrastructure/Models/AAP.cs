using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class AAP
    {
        
        public int AudienceId { get; set; }
        public int AudiencePackId { get; set; }
        public int AudienceCount { get; set; }

        
        public AudiencePack AudiencePack { get; set; }
        public Audience Audience { get; set; }
    }
}
