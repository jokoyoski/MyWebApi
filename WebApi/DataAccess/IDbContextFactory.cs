using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DataAccess
{
   public  interface IDbContextFactory
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns></returns>
        DbContext GetDbContext(string contextType);
    }
}
