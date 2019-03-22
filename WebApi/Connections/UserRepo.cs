using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DataAccess;

namespace WebApi.Connections
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbContextFactory dbContextFactory;


        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public UserRepo(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory??new DbContextFactory();
        }

        public void DeleteUser(int Id)
        {
            using (

              var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
              )
            {
                var joko = db.UserDbs.SingleOrDefault(x => x.Id == Id);
                db.UserDbs.Remove(joko);
            }
        }

        public UserDb GetUserById(int Id)
        {
            using (

               var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
               )
            {
              var joko=  db.UserDbs.SingleOrDefault(x => x.Id == Id);
                return joko;
            }
        }

        //public List<UserDb> GetUsers()
        //{

        //    using (

        //        var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
        //        )
        //    {

        //        var joko = db.UserDbs.ToList();
        //        return joko;
        //    }

        //}

        public List<UserDb> GetUsers()
        {

            using (

                var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
                )
            {

                var joko = db.UserDbs.ToList();
                return joko;
            }

        }
        public UserDb save(UserDb userDb)
        {
            using (

              var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
              )
            {

                db.UserDbs.Add(userDb);
                db.SaveChanges();
            }

            return userDb;
        }



        public UserDb GetUserByEmail(UserDb userDb)
        {

            using (

              var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
              )
            {

                var joko = db.UserDbs.FirstOrDefault(x => x.Email == userDb.Email);
                return joko;
            }
           
        }



        public List<UserDb> saveUser(UserDb userDb)
        {

            using (

               var db = (WebApiEntities)this.dbContextFactory.GetDbContext(ObjectContextValue.WebApi)
               )
            {

                db.UserDbs.Add(userDb);
                db.SaveChanges();
            }
            return new List<UserDb>();
        }
    }
}