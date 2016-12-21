using Microsoft.AspNet.Identity.EntityFramework;
using PNP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNP.API.Services
{
    public class PNPContext : IdentityDbContext<Person>
    {
        public PNPContext()
            : base("PNPContext", throwIfV1Schema: false)
        {
        }

        public static PNPContext Create()
        {
            return new PNPContext();
        }
    }
}
