using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using courses__projectMVC.Models;

namespace courses__projectMVC.Controllers
{
    public class HomeController : Controller
    {
        CourseContext Db;

        public HomeController()
        {
            Db = new CourseContext();
                
        }
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
        #region signup
        [HttpGet]
        public ActionResult signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult signup( User u)
        {
            u.Type = "user";
            if (ModelState.IsValid)
            {
                if (Db.Users.Any(w => w.Email == u.Email))
                {
                    u.LoginErrorMsg = "This Email Already Exists.";
                    return View("signup", u);

                }
                else
                {
                    Db.Users.Add(u);
                    Db.SaveChanges();
                    Session["log"] = "Log out";

                    var val = Db.Users.Where(ww => ww.Email == u.Email);
                    int id = val.Select(ww => ww.id).First();

                    Session["id"] = id;
                    return RedirectToAction("allcourses");
                    Session["type"] = "user";

                }
            }
            else
            {
                return View("signup");
            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userDetails = Db.Users.Where(w => w.Email == user.Email && w.Password == user.Password).FirstOrDefault();
            if (userDetails == null)
            {
                Session["log"] = "Log In";

                Session["id"] = null;
                user.LoginErrorMsg = "Invalid Email or Password";
                return View("Login", user);
            }
            string useroradnin = userDetails.Type;
            Session["type"] = useroradnin;
            Session["log"] = "Log out";

            Session["id"] = userDetails.id;
            if (useroradnin == "admin")
            {
                Session["type"] = "admin";
                return View("addcourse");
            }
            else
            {
                Session["type"] = "user";
                return RedirectToAction("allcourses");
            }
        }

        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["log"] = null;
            Session["type"] = "user";
            /////
            return RedirectToAction("Index");
        }
        #endregion

        #region  about us
        public ActionResult aboutus()
        {
            return View();
        }
        #endregion


        #region contactus
        [HttpGet]
        public ActionResult contactus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult contactus( ContactUs contact)
        {

            if (ModelState.IsValid)
            {
                Db.Contacts.Add(contact);
                Db.SaveChanges();
                contact.ContacterrorMsg = "Message delivered";
                return RedirectToAction("ContactUs", contact);
            }
            else
            {
                contact.ContacterrorMsg = "  The message has not been received";


                return View("ContactUs", contact);
            }
        }
        #endregion

        #region All course

        [HttpGet]
        public ActionResult allcourses()
        {
            if (Session["id"] == null)
            {
                return View("Login");
            }
            else
            {
                var courses = Db.Courses.ToList();

                return View(courses);
            }
        }
        [HttpPost]
        public ActionResult allcourses(Course course)
        {

            var courses = Db.Courses.Where(ww => ww.CourseName == course.CourseName).ToList();

                return View(courses);
            
        }
        #endregion

        #region coursedetails
        [HttpGet]
        public ActionResult coursedetails( int _id)
        {
            var course = Db.Courses.Find(_id);
            return View(course);
        }
        #endregion

        #region checkout
        public ActionResult checkout(int _id)
        {
            var course = Db.Courses.Find(_id);
            return View(course);
        }
        [HttpPost]
        public ActionResult checkout( int i, int p)
        {
            

            Reservation reservation = new Reservation();
            reservation.Course_id = i;
            reservation.Price = p;
            reservation.Reservation_Date = DateTime.Now;
         
          string  l = Session["id"].ToString();
            reservation.User_Id = int.Parse(l);
            if (Db.Reservations.Any(w => w.User_Id == reservation.User_Id && w.Course_id == reservation.Course_id))
            {
                reservation.ReservationrMsg = "This course Already Exists.";
                return RedirectToAction("mycourse");

            }
            else {
                Db.Reservations.Add(reservation);
                Db.SaveChanges();

                return RedirectToAction("mycourse"); 
            }
        }
        #endregion

        #region Add course
        [HttpGet]
        public ActionResult addcourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addcourse( Course course)
        {
            if (ModelState.IsValid)
            {
                Db.Courses.Add(course);
                Db.SaveChanges();
            course.courseErrorMsg= "course is added";
                return RedirectToAction("allcourses", course);
            }
            else
            {
                course.courseErrorMsg = " there exist some problem ";


                return View("addcourse", course);
            }
        }
        #endregion

        #region mycourse
        [HttpGet]
        public ActionResult mycourse()
        {

            if (Session["id"] == null)
            {
                return View("Login");
            }
            else
            {
                string l = Session["id"].ToString();
                int userid = int.Parse(l);
                var reservation = Db.Reservations.Where(ww => ww.User_Id == userid).ToList();
                int count = 0;
                List<Course> courses = new List<Course>();
                foreach (var item in reservation)
                {
                    courses.Add(Db.Courses.Where(ww => ww.Id == item.Course_id).FirstOrDefault());

                }


                return View(courses);
            }
        }
        #endregion
    }
}