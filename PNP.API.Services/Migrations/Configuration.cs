using Constants;
using Microsoft.AspNet.Identity.EntityFramework;
using PNP.API.Model;

namespace PNP.API.Services.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PNP.API.Services.PNPContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PNP.API.Services.PNPContext context)
        {
            //var roleList = context.Roles.Select(x => x.Name).ToList();

            //if (!roleList.Contains(Roles.Admin.ToString()))
            //    context.Roles.Add(new IdentityRole(Roles.Admin.ToString()));

            //if (!roleList.Contains(Roles.User.ToString()))
            //    context.Roles.Add(new IdentityRole(Roles.User.ToString()));

            //if (!roleList.Contains(Roles.Moderator.ToString()))
            //    context.Roles.Add(new IdentityRole(Roles.Moderator.ToString()));

            //if (!context.Users.Any(x => x.UserName == FakeUser.ActiveAdmin.Username))
            //{
            //    var pId = Guid.NewGuid().ToString();

            //    //create one
            //    var p = new Person { Id = pId,
            //                        UserName = FakeUser.ActiveAdmin.Username,
            //                        Email = FakeUser.ActiveAdmin.Email,
            //                        EmailConfirmed = true,
            //                        PhoneNumber = FakeUser.ActiveAdmin.Phone,
            //                        PhoneNumberConfirmed = false,

            //    };
            //    p.Roles.Add(new IdentityUserRole() { RoleId = context.Roles.Single(x => x.Name == Roles.Admin.ToString()).Id, UserId = pId });

            //    context.Users.AddOrUpdate(p);

            //    //var adminRole = ;
            //    //p.Roles.Add(new IdentityUserRole() { RoleId = adminRole.Id, UserId = p.Id });
            //    //context.Users.

            //}
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
