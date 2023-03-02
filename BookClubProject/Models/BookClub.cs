using BookClubProject.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubProject.Models
{
    public class BookClub
    {
        [Key]
        public int id { get; set; }
        public  string? BookName { get; set; }
        public string? Description { get; set; }

        public string? price { get; set; }
        public string? Image { get; set; }

        public BookCategory BookCategory { get; set; }


        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
