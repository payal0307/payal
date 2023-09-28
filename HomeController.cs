using OlxDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxDemo.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      
        public ActionResult Registration()
        {
            
            return View();
        }

        //public ActionResult Registration(RegistrationModel model)
        //{
        //    RegistrationRepo repo = new RegistrationRepo();
        //    RegistrationModel registrationModel = repo.InsertUser(model);

        //    var isEmailAlreadyExists = repo.IsEmailAlreadyExists(model.userEmail);

        //    if (isEmailAlreadyExists)
        //    {
        //        ModelState.AddModelError("userEmail", "This email already exists.");
        //        return View(model);
        //    }

        //bool registrationResult = repo.InsertUser(model);

        //if (registrationResult)
        //{
        //    return RedirectToAction("Login");
        //}
        //else
        //{
        //    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
        //return View(model);
        //}
        //}
        [HttpPost]
        public ActionResult Registration(RegistrationModel obj)
        {
            try
            {
                RegistrationRepo repo = new RegistrationRepo();
                // TODO: Add insert logic here
                repo.InsertUser(obj);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
--====================================================
[HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            RegistrationRepo repo = new RegistrationRepo();

            var isemailalreadyexists = repo.IsEmailAlreadyExists(model.@userEmail);

            if (isemailalreadyexists)
            {
                ModelState.AddModelError("useremail", "this email already exists.");

            }
            else
            {
                bool registrationResult = repo.InsertUser(model);

                if (registrationResult)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return View(model);
                }

            }
            return View(model);

        }
        
            //        [HttpPost]
            //public ActionResult Registration(RegistrationModel obj)
            //{
            //    try
            //    {
            //        RegistrationRepo repo = new RegistrationRepo();
            //        // TODO: Add insert logic here
            //        repo.InsertUser(obj);
            //        //ViewBag.success = "data inserted";

            //        return RedirectToAction(nameof(Index));
            //    }
            //    catch (Exception)
            //    {
            //        return View();
            //    }
            // }

            //public ActionResult Addlist()
            //{
            //    return View();
            //}
        }

    }

