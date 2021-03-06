﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
    public static class FakeUser
    {
        public static FakeUsers ActiveAdmin = new FakeUsers();
        public static FakeUsers ActiveUser = new FakeUsers();
        public static FakeUsers ActiveModerator = new FakeUsers();

        static FakeUser()
        {
            ActiveAdmin.Email = "some.admin@pnp.com";
            ActiveAdmin.Username = "sadmin";
            ActiveAdmin.Phone = "1111111111";

            ActiveUser.Email = "some.user@pnp.com";
            ActiveUser.Username = "sUser";
            ActiveUser.Phone = "3333333333";

            ActiveModerator.Email = "some.moderator@pnp.com";
            ActiveModerator.Username = "sModerator";
            ActiveModerator.Phone = "2222222222";
        }
    }

    public class FakeUsers
    {
        public FakeUsers() { }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
