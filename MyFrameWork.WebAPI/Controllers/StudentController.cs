using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFrameWork.Models.Models;
using MyFrameWork.Services.Interface;
using MyFrameWork.WebAPI.Attributes;

namespace MyFrameWork.WebAPI.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public IStudentService StudentService { set; get; }  
        
        //[Authorize]
        [Log]
        public ActionResult Index()
        {
            Student student = StudentService.FindByOptons(s => s.StudentID == 1).FirstOrDefault() ;

            return Json("sdfa",JsonRequestBehavior.AllowGet);
        }

    }
}
