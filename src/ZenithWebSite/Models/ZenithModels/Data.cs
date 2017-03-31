using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebSite.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebSite.Models.ZenithModels
{
    public class Data
    {

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }



        public static void Initialize(ApplicationDbContext db)
        {

            

            if (!db.Roles.Any(r => r.Name == "Admin"))
            {
                db.Roles.Add(new IdentityRole
                {
                    Name = "Admin"
                });
            }

            if (!db.Roles.Any(r => r.Name == "Member"))
            {
                db.Roles.Add(new IdentityRole
                {
                    Name = "Member"
                });
            }

            if (!db.Users.Any(u => u.UserName == "a"))
            {
                var adminProfile = new ApplicationUser
                {
                    UserName = "a",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "a@a.a"
                };

                db.Users.Add(adminProfile);

                db.SaveChanges();

                if (!db.Users.Any(u => u.UserName == adminProfile.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(adminProfile, "P@ssw0rd");
                    adminProfile.PasswordHash = hashed;

                    var userStore = new UserStore<ApplicationUser>(db);
                    var result = userStore.CreateAsync(adminProfile);

                }
                db.SaveChanges();

            }

            if (!db.Users.Any(u => u.UserName == "m")) { 
                var memberProfile = new ApplicationUser
                {
                    UserName = "m",
                    FirstName = "Member",
                    LastName = "User",
                    Email = "m@m.m"
                };

                db.Users.Add(memberProfile);

                db.SaveChanges();
            }

            if (!db.Activities.Any())
            {
                db.Activities.Add
                  (new Activity()
                  {
                      Description = "Senior's Golf Tournament",
                      CreationDate = DateTime.Now
                  });

                db.Activities.Add(new Activity()
                {
                    Description = "Leadership General Assembly Meeting",
                    CreationDate = DateTime.Now
                });

                db.Activities.Add(new Activity()
                {
                    Description = "Youth Bowling Tournament",
                    CreationDate = DateTime.Now
                });

                db.Activities.Add(new Activity()
                {
                    Description = "Young ladies cooking lessons",
                    CreationDate = DateTime.Now
                });

                db.Activities.Add(new Activity()
                {
                    Description = "Youth craft lessons",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Youth choir practice",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Lunch",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Pancake Breakfast",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Swimming Lessons for the youth",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Swimming Exercise for parents",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Bingo Tournament",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "BBQ Lunch",
                    CreationDate = DateTime.Now
                });
                db.Activities.Add(new Activity()
                {
                    Description = "Garage Sale",
                    CreationDate = DateTime.Now
                });

                db.SaveChanges();
            };


            if (!db.Events.Any())
            {
                db.Events.Add(new Event
                {
                    EventStart = new DateTime(2017, 4, 4, 8, 30, 0),
                    EventEnd = new DateTime(2017, 4, 4, 10, 30, 0),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityId = db.Activities.FirstOrDefault(f => f.Description == "Senior's Golf Tournament").ActivityId
                });
                db.Events.Add(new Event
                {
                    EventStart = new DateTime(2017, 4, 5, 8, 30, 0),
                    EventEnd = new DateTime(2017, 4, 5, 10, 30, 0),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityId = db.Activities.FirstOrDefault(f => f.Description == "Leadership General Assembly Meeting").ActivityId
                });
                db.Events.Add(new Event
                {
                    EventStart = new DateTime(2017, 4, 7, 17, 30, 0),
                    EventEnd = new DateTime(2017, 4, 7, 19, 15, 0),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityId = db.Activities.FirstOrDefault(f => f.Description == "Youth Bowling Tournament").ActivityId
                });
                db.Events.Add(new Event
                {
                    EventStart = new DateTime(2017, 4, 7, 19, 00, 0),
                    EventEnd = new DateTime(2017, 4, 7, 20, 00, 0),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityId = db.Activities.FirstOrDefault(f => f.Description == "Young ladies cooking lessons").ActivityId
                });
                db.Events.Add(new Event
                {
                    EventStart = new DateTime(2017, 4, 8, 8, 30, 0),
                    EventEnd = new DateTime(2017, 4, 8, 10, 30, 0),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityId = db.Activities.FirstOrDefault(f => f.Description == "Youth craft lessons").ActivityId
                });


            };

            db.SaveChanges();


        }



    }
}
