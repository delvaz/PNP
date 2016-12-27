using Microsoft.AspNet.Identity.EntityFramework;
using PNP.API.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PNP.API.Services
{
    public class PNPContext : IdentityDbContext<Person>
    {
        public PNPContext()
            : base("PNPContext", throwIfV1Schema: false)
        {
            //Database.SetInitializer<PNPContext>(null);
        }



        public IQueryable<Person> Persons => Users;

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<PrayerRequest> PrayerRequests { get; set; }

        public static PNPContext Create()
        {
            return new PNPContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasMany(u => u.Groups)
                .WithMany(r => r.Members)
                .Map(ur =>
                {
                    ur.ToTable("AspNetUserGroups");
                    ur.MapLeftKey("Id");
                    ur.MapRightKey("GroupId");
                });

            modelBuilder.Entity<PrayerRequest>()
                .HasMany(u => u.Groups)
                .WithMany(r => r.PrayerRequests)
                .Map(ur =>
                {
                    ur.ToTable("PrayerRequestGroups");
                    ur.MapLeftKey("PrayerRequestId");
                    ur.MapRightKey("GroupId");
                });

        }
    }
}
