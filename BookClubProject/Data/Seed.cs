using BookClubProject.Data.Enum;
using BookClubProject.Models;
using System.Diagnostics;
using System.Net;

namespace BookClubProject.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.BookClubs.Any())
                {
                    context.BookClubs.AddRange(new List<BookClub>()
                    {
                        new BookClub()
                        {
                            BookName="Alice in wonderland",
                            Description="a sweet book of how alice went to wonderland or somthing like that",
                            BookCategory= BookCategory.Sci_fi,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            price="R350.00"
                        },
                        new BookClub()
                        {
                                BookName="Alice in wonderland",
                            Description="a sweet book of how alice went to wonderland or somthing like that",
                            BookCategory= BookCategory.Sci_fi,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            price="R200.00"
                        },
                        new BookClub()
                        {
                            BookName="Alice in wonderland",
                            Description="a sweet book of how alice went to wonderland or somthing like that",
                            BookCategory= BookCategory.Sci_fi,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            price="R450.00"
                        },
                         new BookClub()
                        {
                            BookName="Alice in wonderland",
                            Description="a sweet book of how alice went to wonderland or somthing like that",
                            BookCategory= BookCategory.Sci_fi,
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            price="R10.00"
                        } });
                    context.SaveChanges();
                }
                
              
            }
        }

    }
}
