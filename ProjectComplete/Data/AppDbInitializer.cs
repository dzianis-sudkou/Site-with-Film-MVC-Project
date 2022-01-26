using Microsoft.AspNetCore.Identity;
using ProjectComplete.Data.Enums;
using ProjectComplete.Data.Static;
using ProjectComplete.Models;

namespace ProjectComplete.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Add Collections 
                if (!context.Collections.Any())
                {
                    context.Collections.AddRange(new List<Collection>()
                    {
                        new Collection()
                        {
                            Name = "Первая Коллекция",
                            Description = "Это описание первой коллекции",
                            Theme = Theme.Book,
                            ImageUrl = "https://cdn.pixabay.com/photo/2017/07/02/09/03/books-2463779_960_720.jpg"
                        },
                        new Collection()
                        {
                            Name = "Вторая коллекция",
                            Description = "Это описание второй коллекции",
                            Theme = Theme.Film,
                            ImageUrl = "https://cdn.pixabay.com/photo/2017/08/06/06/55/comics-2589659_960_720.jpg"
                        },
                        new Collection()
                        {
                            Name = "Третья коллекция",
                            Description = "Это описание третьей коллекции",
                            Theme = Theme.Alcohol,
                            ImageUrl = "https://cdn.pixabay.com/photo/2021/12/18/06/01/wine-6878013_960_720.jpg"
                        },
                    });
                    context.SaveChanges();
                }


                //Add Items
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Первый Item",
                            Description = "Я отношусь к первой коллекции",
                            CollectionId = 1,
                        },
                        new Item()
                        {
                            Name = "Second Item",
                            Description = "Я отношусь к первой коллекции",
                            CollectionId = 1,
                        },
                        new Item()
                        {
                            Name = "Third Item",
                            Description = "Я отношусь к третьей коллекции",
                            CollectionId = 3,
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {

            //Делаю Роли
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles Section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@itr.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newadminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newadminUser, "@Pr6");
                    await userManager.AddToRoleAsync(newadminUser, UserRoles.Admin);
                }
                string appUserEmail = "user@itr.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newappUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newappUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newappUser, UserRoles.User);
                }
            }

        }
    }
}