using Backend.Infrastructure.Models;
using System.Security.Claims;

namespace Backend.Model
{
    public class UserFromJWT
    {
        public string Login { get; set; }
        public string Role { get; set; }
        public int ProfileId { get; set; }
    }
}