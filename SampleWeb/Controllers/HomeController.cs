using SampleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Your index description page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your login page.";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your registration page.";

            return View();
        }
        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String fname = fc["fname"];
            String lname = fc["lname"];
            String email = fc["email"];
            String password = fc["password"];

            User use = new User();
            use.FirstName = fname;
            use.LastName = lname;
            use.Email = email;
            use.Password = password;
            use.RoleID = 1;

            friendsEntities4 fe = new friendsEntities4();
            fe.Users.Add(use);
            fe.SaveChanges();

            return RedirectToAction("Input");
        }
        public ActionResult UserUpdate()
        {
            friendsEntities4 rdbe = new friendsEntities4();
            User u = (from a in rdbe.Users
                      where a.UserID == 1
                      select a).FirstOrDefault();
            u.FirstName = "april";
            u.LastName = "taurus";
            u.Email = "zodiac@gmail.com";
            u.Password = "1234";
            u.RoleID = 2;
            rdbe.SaveChanges();

            return View();
        }
        public ActionResult UserDelete()
        {
            friendsEntities4 rdbe = new friendsEntities4();
            User u = (from a in rdbe.Users
                      where a.UserID == 3
                      select a).FirstOrDefault();
            rdbe.Users.Remove(u);
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult ShowUser()
        {
            friendsEntities4 fe = new friendsEntities4();
            var userList = (from a in fe.Users
                            select a).ToList();

            ViewData["UserList"] = userList;

            return View();
        }
    }

}