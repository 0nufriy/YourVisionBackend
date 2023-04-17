using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
