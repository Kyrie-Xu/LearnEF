using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFrameWork.Services.Interface;
using System.Linq.Expressions;
using MyFrameWork.Models;
using MyFrameWork.Dao.Interface;
using MyFrameWork.Models.Models;

namespace MyFrameWork.Services.Implement
{
    public class StudentService : IStudentService
    {
        private IStudentDao StudentDao { set; get; }

        public StudentService() 
        {

        }

        public List<Student> FindByOptons(Expression<Func<Student, bool>> selector)
        {
            return StudentDao.FindByOptions(selector);
        }
    }
}
