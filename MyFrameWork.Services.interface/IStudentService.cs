using MyFrameWork.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Services.Interface
{
    public interface IStudentService
    {
        List<Student> FindByOptons(Expression<Func<Student, bool>> selector);
    }
}
