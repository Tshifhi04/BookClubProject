using BookClubProject.Data.Enum;
using BookClubProject.Models;

namespace BookClubProject.ViewModel
{
    public class BookClubViewModel
    {

        public int id { get; set; }
        public string? BookName { get; set; }
        public string? Description { get; set; }

        public string? price { get; set; }
        public IFormFile Image { get; set; }

        public BookCategory BookCategory { get; set; }


    }
}
