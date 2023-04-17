using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportPath { get; set; }
        public int SessionId { get; set; }

        public Session Session { get; set; }
    }
}
