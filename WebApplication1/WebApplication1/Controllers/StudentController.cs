using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login2(String txtLogin, String txtPassword)
        {
            ViewBag.UserName = txtLogin;

            if(String.IsNullOrEmpty(txtLogin)  == true){
                ViewBag.Error = "Login is mandatory!";                
                return View("Login");
            }
            else if (String.IsNullOrEmpty(txtPassword) == true)
            {
                ViewBag.Error = "Password is mandatory!";
                return View("Login");
            }

            //String str = Request["txtLogin"];
            //String pswd = Request["txtPassword"];
            //if (DummyDBManager.ValidateUser(txtLogin, txtPassword) == true)
            BAL.StudentBAL balObj = new BAL.StudentBAL();
            if (balObj.ValidateUser(txtLogin, txtPassword) == true)
            {
                Session["User"] = txtLogin;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid User/Name Password";
                return View("Login");
            }
            
        }

        public ActionResult ShowAll() {

            List<StudentDTO> list = DummyDBManager.GetStudents();

            ViewBag.Students = list;

            return View();
        }

        public PartialViewResult ShowAll2()
        {
            BAL.StudentBAL balObj = new BAL.StudentBAL();
            List<StudentDTO> list = balObj.GetAllStudents();

            return View(list);
        }

        public JsonResult ShowAll3()
        {
            BAL.StudentBAL balObj = new BAL.StudentBAL();
            List<StudentDTO> list = balObj.GetAllStudents();

            return Json(list, JsonRequestBehavior.AllowGet);
        }


    }
}