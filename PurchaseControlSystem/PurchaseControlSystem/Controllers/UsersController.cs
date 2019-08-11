using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseControlSystem.Models;

namespace PurchaseControlSystem.Controllers
{
    public class UsersController : Controller
    {
        private Purchase_Control_SystemEntities db = new Purchase_Control_SystemEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Cost_Center).Include(u => u.Department).Include(u => u.Location).Include(u => u.Team);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CostCenter_FK = new SelectList(db.Cost_Center, "CostCenterId", "Description");
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name");
            ViewBag.Location_FK = new SelectList(db.Locations, "Location1", "Description");
            ViewBag.TeamId_FK = new SelectList(db.Teams, "TeamId", "TeamName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password,EmployeeNo,Name,DepartmentId_FK,CostCenter_FK,Email,Phone,Role,PrintFormat,DivisionAccess,Grade,OperationsApprover,FinanceApprover,VendModAccess,Signature,TeamApplicable,TeamId_FK,Out_Of_Office,StartDate,EndDate,Comments,Location_FK,Terminal")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CostCenter_FK = new SelectList(db.Cost_Center, "CostCenterId", "CostCenterId", user.CostCenter_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", user.DepartmentId_FK);
            ViewBag.Location_FK = new SelectList(db.Locations, "Location1", "Description", user.Location_FK);
            ViewBag.TeamId_FK = new SelectList(db.Teams, "TeamId", "TeamName", user.TeamId_FK);
            //ViewBag.Name = new SelectList(db.Users, "UserId", "Name", user.Name);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CostCenter_FK = new SelectList(db.Cost_Center, "CostCenterId", "Description", user.CostCenter_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", user.DepartmentId_FK);
            ViewBag.Location_FK = new SelectList(db.Locations, "Location1", "Description", user.Location_FK);
            ViewBag.TeamId_FK = new SelectList(db.Teams, "TeamId", "TeamName", user.TeamId_FK);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Password,EmployeeNo,Name,DepartmentId_FK,CostCenter_FK,Email,Phone,Role,PrintFormat,DivisionAccess,Grade,OperationsApprover,FinanceApprover,VendModAccess,Signature,TeamApplicable,TeamId_FK,Out_Of_Office,StartDate,EndDate,Comments,Location_FK,Terminal")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CostCenter_FK = new SelectList(db.Cost_Center, "CostCenterId", "Description", user.CostCenter_FK);
            ViewBag.DepartmentId_FK = new SelectList(db.Departments, "DepartmentId", "Department_name", user.DepartmentId_FK);
            ViewBag.Location_FK = new SelectList(db.Locations, "Location1", "Description", user.Location_FK);
            ViewBag.TeamId_FK = new SelectList(db.Teams, "TeamId", "TeamName", user.TeamId_FK);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var userauth = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            if (userauth == null)
            {
                return ViewBag.error = ("Invalid username or password");
                // return View(u);
                //return Content("no");
            }
            else
            {
                Session["userId"] = userauth.UserId;
                Session["username"] = userauth.Username;
                Session["financeApp"] = userauth.FinanceApprover;
                Session["operationApp"] = userauth.OperationsApprover;
                Session["grade"] = userauth.Grade;
                Session["divAccess"] = userauth.DivisionAccess;
                //return RedirectToAction("LogIn","Dashboard");
                return RedirectToAction("Dashboard", "Home");
            }

            //return ();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
