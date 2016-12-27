using PNP.API.Model;
using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Authentication;
using PNP.API.Services;
using Xunit;

namespace PNP.WebAPI.Model.Tests
{
    public class ModelTests
    {
        private readonly PNPContext _context;

        public ModelTests()
        {
            _context = new PNPContext();
        }

        [Fact]
        public void FakeUser_CanBeCreated()
        {
            var user = Constants.FakeUser.ActiveAdmin;

            Assert.NotNull(user);
        }

        #region Persons
        [Fact]
        public void Persons_Can_Register()
        {
            throw new NotImplementedException();

        }

        [Fact]
        public void Persons_Can_Login()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Persons_CanCreate_PrayerRequests()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Persons_CanSend_PrayerRequests()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Persons_CanBeGrouped()
        {
            var count = _context.Persons.Count(x => x.Groups.Any());
            Assert.True(count > 0);
        }

        [Fact]
        public void Persons_CanBeInMultipleGroups()
        {
            var count = _context.Persons.Count(x => x.Groups.Count > 1);
            Assert.True(count > 0);
        }

        [Fact]
        public void Persons_CanReply_ToPrayerRequests()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Persons_CanReply_ToPrayerRequestSendee()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Promises
        [Fact]
        public void Promises_AreOptional()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Promises_CanBeAttachedTo_PrayerRequests()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Prayer Requests

        [Fact]
        public void PrayerRequests_CanBeCreated()
        {
            var existingCount = _context.PrayerRequests.Count();

            var pr = new PrayerRequest
            {
                TargetDate = DateTime.Now.AddDays(30),
                CloseDate = DateTime.Now.AddDays(40),
                Title = "Prayer Request " + (existingCount + 1),
                Description = "This is a sample prayer request."
            };

            pr.Groups.Add(_context.Groups.First(x => x.Name == "Test Group 1"));

            _context.PrayerRequests.AddOrUpdate(pr);
            _context.SaveChanges();

            var newCount = _context.PrayerRequests.Count();
            Assert.Equal(existingCount+1, newCount);

        }


        [Fact(Skip = "Pending repository")]
        public void PrayerRequests_MustHave_Groups()
        {
            var p = _context.PrayerRequests.SingleOrDefault(x => x.PrayerRequestId == 1);

            Assert.NotNull(p);
            Assert.True(p.Groups.Any());

            p.Groups.Clear();
            _context.PrayerRequests.AddOrUpdate(p);
            Exception ex = Assert.Throws<Exception>(() => _context.SaveChanges());
        }

        [Fact]
        public void PrayerRequests_CanHaveMultiple_Groups()
        {
            var count = _context.PrayerRequests.Count(x => x.Groups.Count > 1);

            Assert.NotEqual(count, 0);
        }

        //ppl cannot reply to prayer requests with a prior close date
        [Fact]
        public void PrayerRequests_TargetAndClose_MustBeGreaterThan_OpenDate()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PrayerRequests_Target_MustBeLessThan_CloseDate()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PrayerRequests_CannotReplyTo_ClosedRequests()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
