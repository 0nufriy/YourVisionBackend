using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOTI.Model
{
    public class AudiencePackNeed
    {
        public int AudiencePackId { get; set; }
        public string AudiencePackName { get; set; }
        public int Price { get; set; }
        public decimal PriceByOnePerson { get; set; }
        public int count = 0;
        public List<AAPDTO> Audiences { get; set; }
    }
}
