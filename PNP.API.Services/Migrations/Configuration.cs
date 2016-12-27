using System.Diagnostics;
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
        private static readonly string[] GroupNames = { "Test Group 1", "Test Group 2" };
        private static readonly string[] PrayerRequestNames = { "Prayer Request 1", "Prayer Request 2" };

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PNP.API.Services.PNPContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached == false)
                Debugger.Launch();

            AddRoles(context);

            AddUsers(context);

            AddGroups(context);

            AddUserGroups(context);

            AddPrayerRequests(context);

        }

        private void AddPrayerRequests(PNPContext context)
        {
            foreach (var title in PrayerRequestNames)
            {
                if (!context.PrayerRequests.Any(x=>x.Title == title))
                {
                    var pr = new PrayerRequest {Title = title, Description = "Some new description for " + title, CreateDate = DateTime.Now.AddDays(-5), CloseDate = DateTime.Now.AddMonths(2), TargetDate = DateTime.Now.AddMonths(1)};
                }

                var p = context.PrayerRequests.Single(x => x.Title == title);

                var testGroups = context.Groups.Where(x => GroupNames.Contains(x.Name)).ToList();

                foreach (var g in testGroups)
                {
                    if (p.Groups.All(x => x.Name != g.Name))
                    {
                        p.Groups.Add(g);
                    }

                }

                context.PrayerRequests.AddOrUpdate(p);
                context.SaveChanges();

            }
        }

        private void AddUserGroups(PNPContext context)
        {
            var activeAdmin = context.Users.First(x => x.Email == FakeUser.ActiveAdmin.Email);
            foreach (var name in GroupNames)
            {
                var g = context.Groups.Single(x => x.Name == name);
                g.Members.Add(activeAdmin);
                context.Groups.AddOrUpdate(g);
            }
        }

        #region Private Functions
        private static void AddGroups(PNPContext context)
        {
            var activeAdmin = context.Users.First(x => x.Email == FakeUser.ActiveAdmin.Email);

            foreach (var name in GroupNames)
            {
                if (!context.Groups.Any(x => x.Name == name))
                {
                    var g = new Group {Moderator = activeAdmin, ModeratorId = activeAdmin.Id, Name = name};
                    context.Groups.AddOrUpdate(g);
                    context.SaveChanges();
                }
            }
        }

        private static void AddUsers(PNPContext context)
        {
            if (!context.Users.Any(x => x.UserName == FakeUser.ActiveAdmin.Username))
            {
                var pId = Guid.NewGuid().ToString();

                //create one
                var p = new Person {Id = pId, UserName = FakeUser.ActiveAdmin.Username, Email = FakeUser.ActiveAdmin.Email, EmailConfirmed = true, PhoneNumber = FakeUser.ActiveAdmin.Phone, PhoneNumberConfirmed = false,};
                p.Roles.Add(new IdentityUserRole() {RoleId = context.Roles.Single(x => x.Name == Roles.Admin.ToString()).Id, UserId = pId});
                context.Users.AddOrUpdate(p);
            }

            if (!context.Users.Any(x => x.UserName == FakeUser.ActiveUser.Username))
            {
                var pId = Guid.NewGuid().ToString();

                //create one
                var p = new Person { Id = pId, UserName = FakeUser.ActiveUser.Username, Email = FakeUser.ActiveUser.Email, EmailConfirmed = true, PhoneNumber = FakeUser.ActiveUser.Phone, PhoneNumberConfirmed = false, };
                p.Roles.Add(new IdentityUserRole() { RoleId = context.Roles.Single(x => x.Name == Roles.User.ToString()).Id, UserId = pId });
                context.Users.AddOrUpdate(p);
            }

            if (!context.Users.Any(x => x.UserName == FakeUser.ActiveModerator.Username))
            {
                var pId = Guid.NewGuid().ToString();

                //create one
                var p = new Person { Id = pId, UserName = FakeUser.ActiveModerator.Username, Email = FakeUser.ActiveModerator.Email, EmailConfirmed = true, PhoneNumber = FakeUser.ActiveModerator.Phone, PhoneNumberConfirmed = false, };
                p.Roles.Add(new IdentityUserRole() { RoleId = context.Roles.Single(x => x.Name == Roles.Moderator.ToString()).Id, UserId = pId });
                context.Users.AddOrUpdate(p);
            }
        }

        private static void AddRoles(PNPContext context)
        {

            var roleList = context.Roles.Select(x => x.Name).ToList();

            if (!roleList.Contains(Roles.Admin.ToString()))
                context.Roles.Add(new IdentityRole(Roles.Admin.ToString()));

            if (!roleList.Contains(Roles.User.ToString()))
                context.Roles.Add(new IdentityRole(Roles.User.ToString()));

            if (!roleList.Contains(Roles.Moderator.ToString()))
                context.Roles.Add(new IdentityRole(Roles.Moderator.ToString()));
        }
        #endregion
    }
}
