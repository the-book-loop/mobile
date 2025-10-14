using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string About { get; set; }
        public double Rating { get; set; }
        public List<string> FavoriteGenres { get; set; }
    }
}
