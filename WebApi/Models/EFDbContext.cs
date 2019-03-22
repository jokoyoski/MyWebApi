using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class EFDbContext :DbContext
    {
        public DbSet<User>users { get; set; }

        public System.Data.Entity.DbSet<WebApi.DataAccess.UserDb> UserDbs { get; set; }
    }
}