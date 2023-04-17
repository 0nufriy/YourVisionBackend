using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Audience
    {
        public int AudienceId { get; set; }
        public int Age {  get; set; }
        public bool Sex { get; set; }

        public List<AAP> AAPs { get; set; }
    }
}
