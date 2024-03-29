﻿using BookClubProject.Data.Enum;
using BookClubProject.Models;
using Microsoft.AspNetCore.Identity;
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


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "vhuhulwi04@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "chifhi",
                        Email = adminUserEmail,
                        EmailConfirmed = true,

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        //Address = new Address()
                        //{
                        //    Street = "123 Main St",
                        //    City = "Charlotte",
                        //    State = "NC"
                        //}
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
                //    }
            }
        }
    }
}
