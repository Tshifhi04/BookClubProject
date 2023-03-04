using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace BookClubProject.Models
{
    public class AppUser : IdentityUser
    {
        //[Key]
        //public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
      public ICollection<BookClub> BookClubs { get; set; }
    }
}
