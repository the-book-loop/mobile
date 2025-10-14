using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile.Models
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequestModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponseModel
    {
        public string Token { get; set; }
        public User UserProfile { get; set; }
    }
}
