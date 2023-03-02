using BookClubProject.Data;
using BookClubProject.Interfaces;
using BookClubProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookClubProject.Repository
{
    public class BookClubRepository :IBookClubRepository
    {
        private readonly ApplicationDbContext _context;
        public BookClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(BookClub bookClub)
        {
            _context.Remove(bookClub);
            return Save();
        }

        public async  Task<IEnumerable<BookClub>> GetAll()
        {
            return await _context.BookClubs.ToListAsync();
        }

        public  async Task<BookClub> GetByIdAsync(int id)
        {
            return await _context.BookClubs.Include(i => i.AppUser).FirstOrDefaultAsync(i =>i.id ==id);
        }
        public bool Add(BookClub bookClub)
        {
            _context.Add(bookClub);
            return Save();
        }

        public bool Save()
        {
            var saved =_context.SaveChanges();
            return saved > 0? true : false;
        }

        public bool Update(BookClub bookClub)
        {
            _context.Update(bookClub);
            return Save();
        }
    }
}
