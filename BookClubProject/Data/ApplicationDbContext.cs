using BookClubProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookClubProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<BookClub> BookClubs { get; set; }
    }
}
