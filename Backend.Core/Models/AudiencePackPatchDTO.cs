using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class AudiencePackPatchDTO
    {
        public int AudiencePackId { get; set; }
        public string AudiencePackName { get; set; }
        public int Price { get; set; }

        public List<AAPDTO> Audiences { get; set; }
    }
}
