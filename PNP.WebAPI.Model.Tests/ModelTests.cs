using PNP.API.Model;
using System;
using Xunit;

namespace PNP.WebAPI.Model.Tests
{

    public class ModelTests
    {
        [Fact]
        public void FakeUser_CanBeCreated()
        {
            var user = Constants.FakeUser.ActiveAdmin;

            Assert.NotNull(user);
        }

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
            throw new NotImplementedException();
        }

        [Fact]
        public void Persons_CanBeInMultipleGroups()
        {
            throw new NotImplementedException();
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
    }
}
