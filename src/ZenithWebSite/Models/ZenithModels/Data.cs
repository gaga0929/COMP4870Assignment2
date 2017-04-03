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
       
        
        public static void Initialize(ApplicationDbContext db, IServiceProvider serviceProvider)
        {
            var roleStore = new RoleStore<IdentityRole>(db);

            if (!db.Roles.Any(r => r.Name == "Admin"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
            }

            db.SaveChanges();

            if (!db.Roles.Any(r => r.Name == "Member"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "Member", NormalizedName = "Member" });
            }

            db.SaveChanges();

            if (!db.Users.Any(u => u.UserName == "a"))
            {
                var adminProfile = new ApplicationUser
                {
                    UserName = "a",
                    NormalizedUserName = "A",
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "a@a.a",
                    NormalizedEmail = "A@A.A",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                db.Users.Add(adminProfile);

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(adminProfile, "P@$$w0rd");
                adminProfile.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(db);
                var result = userStore.CreateAsync(adminProfile);

                userStore.AddToRoleAsync(adminProfile, "Admin");
                userStore.AddToRoleAsync(adminProfile, "Member");

                db.SaveChanges();

            }

            if (!db.Users.Any(u => u.UserName == "m")) { 
                var memberProfile = new ApplicationUser
                {
                    UserName = "m",
                    NormalizedUserName = "M",
                    FirstName = "Member",
                    LastName = "User",
                    Email = "m@m.m",
                    NormalizedEmail = "M@M.M",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                db.Users.Add(memberProfile);

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(memberProfile, "P@$$w0rd");
                memberProfile.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(db);
                var result = userStore.CreateAsync(memberProfile);

                userStore.AddToRoleAsync(memberProfile, "Member");
                
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
