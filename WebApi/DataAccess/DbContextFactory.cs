using System;
using System.Collections.Generic;
using System.Linq;
using Environment = AA.Infrastructure.Utility.Environment;

using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using AA.Infrastructure.Interfaces;
using System.Data.Common;

namespace WebApi.DataAccess
{
    public class DbContextFactory:IDbContextFactory
    {
        //private readonly IEnvironment environment;

        //public DbContextFactory(IEnvironment environment)
        //{
        //    this.environment = environment ?? new Environment();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextType"></param>
        /// <returns></returns>
        public DbContext GetDbContext(string contextType)
        {
            if (string.IsNullOrEmpty(contextType))
            {
                throw new ArgumentNullException("contextType");
            }

            DbContext dbContext = null;

            //var userId = "sa";
            //var password = "automata01";
            //var server = "localhost";

            var userId = "Makanga";
            var password = "Jokoyoski200@";
            var server = "jokoyoskimakanga.database.windows.net,1433";

            if (string.IsNullOrEmpty(server))
            {
                throw new ApplicationException(string.Format("Server not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException(string.Format("UserId not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ApplicationException(string.Format("Password not specified in Environment file for database{0}",
                    contextType));
            }

            string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server,
                contextType, userId, password);

            var entities = new EntityConnectionStringBuilder
            {
                Metadata = @"res://*/DataAccess.WebApi.csdl|res://*/DataAccess.WebApi.ssdl|res://*/DataAccess.WebApi.msl",
                ProviderConnectionString = connString,
                Provider = "System.Data.SqlClient"
            };

            DbConnection dbConnection = new EntityConnection(entities.ConnectionString);
            dbContext = new WebApiEntities(dbConnection, true);


            return dbContext;
        }
    }
}