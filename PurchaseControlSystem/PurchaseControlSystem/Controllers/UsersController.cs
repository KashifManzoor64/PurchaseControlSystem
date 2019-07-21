using PurchaseControlSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace PurchaseControlSystem.Controllers
{
    //[Authorize]
    public class UsersController : Controller
    {
        
        Purchase_Control_SystemEntities1 db = new Purchase_Control_SystemEntities1();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(User u)
        {

            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("LogIn");
            }
            else {
                return View(u);
                    }
        }
        public ActionResult LogIn()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult LogIn(string Username, string Password)
        {
            var userauth = db.Users.Where(x => x.Username_FK == Username && x.Password == Password).FirstOrDefault();
            if (userauth == null)
            {
                //ViewBag("wrong username or password");
                // return View(u);
                return Content("no");
            }
            else
            {
                Session["userId"] = userauth.User_Id;
                //return RedirectToAction("LogIn","Dashboard");
                return Content("ok");
            }

        }
    }
}