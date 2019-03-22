using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebApi.DataAccess
{
    
        public partial class WebApiEntities
    {
            public WebApiEntities(DbConnection dbConnection, bool contextOwnsConnection)
                : base(dbConnection, contextOwnsConnection)
            {
            }
        }
    
}