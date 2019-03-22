using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Connections;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UsersController:ApiController
    {

        private readonly IUserRepo userRepo;

        public UsersController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
       
        public UsersController()
        {

        }
        // WebApiEntities db = new WebApiEntities();
        [Route("api/Users")]
        public HttpResponseMessage getUser()
        {
          //  UserDb userDb = new UserDb();
            UserRepo userRepo = new UserRepo(null);
            var joko = userRepo.GetUsers();
            return Request.CreateResponse(HttpStatusCode.OK,joko);


        }

        [HttpPost]
        [Route("api/CreateUser")]
        public HttpResponseMessage createuser(UserDb user)
        {
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            UserRepo userRepo = new UserRepo(null);
           var joko= userRepo.save(user);
            //db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK,joko);
        }
        [Route("api/loginuser")]
        public HttpResponseMessage loginuser(UserDb user)
        {
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            if (!ModelState.IsValid)

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            UserRepo userRepo = new UserRepo(null);
           var joko= userRepo.GetUserByEmail(user);
            if(joko==null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
           
            return Request.CreateResponse(HttpStatusCode.OK,joko);
        }

        

        public UserDb getUser(int Id)
        {

        var joko = this.userRepo.GetUserById(Id);
        
           if (joko == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return joko;
            
            
        }



        [HttpPut]
        public HttpResponseMessage UpdateUser(User user)
        {

            var users = this.userRepo.GetUserById(user.Id);
            if (users == null)
                throw new HttpRequestException();
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        public void DeleteUser(int Id)
        {
           this.userRepo.DeleteUser(Id);
        }
    }
}
