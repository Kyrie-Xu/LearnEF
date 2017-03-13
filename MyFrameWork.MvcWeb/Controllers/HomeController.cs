using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFrameWork.Services.Interface;
using MyFrameWork.EF;

namespace MyFrameWork.MvcWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /home/

        public IStudentService StudentService { set; get; }

        public ActionResult Index()
        {
            Student student = StudentService.FindByOptons(s=>s.StudentID == 1).FirstOrDefault();
            ViewBag.StudentName = student == null ? "没有学生" : student.StudentName;
            return View();
        }

    }
}
