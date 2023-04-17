using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Models
{
    public class ReportGetDTO
    {
        public int ReportId { get; set; }
        public string ReportPath { get; set; }
        public int SessionId { get; set; }
    }
}
