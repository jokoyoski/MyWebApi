using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Connections;
using WebApi.DataAccess;

namespace WebApi.Controllers
{
    public class WebController : Controller
    {

        private readonly IUserRepo userRepo;

        public WebController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

       // UserRepo user = new UserRepo(null);

        // GET: Web
        public JsonResult Index()
        {
            UserDb userDb = new UserDb();
            var joko = this.userRepo.GetUsers();
            return Json(joko,JsonRequestBehavior.AllowGet);

        }

                


        public ActionResult GetUserById(int Id)
        {
          var joko=  this.userRepo.GetUserById(Id);
            return View(joko);
        }
                

            

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserDb userDb)
        {
            this.userRepo.save(userDb);
           
                return RedirectToAction("index");
            }
            
        }
    }
