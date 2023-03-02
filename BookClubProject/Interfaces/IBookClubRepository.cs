using BookClubProject.Models;

namespace BookClubProject.Interfaces
{
    public interface IBookClubRepository
    {
        Task<IEnumerable<BookClub>> GetAll();
        Task<BookClub> GetByIdAsync(int id);

        bool Add(BookClub bookClub);
        bool Update(BookClub bookClub);
        bool Delete(BookClub bookClub);
        bool Save();

    }
}
