using MyFrameWork.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MyFrameWork.Dao.Interface
{
    public interface IStudentDao
    {
        void Add(Student student);
        List<Student> FindByOptions(Expression<Func<Student, bool>> selector);
        void Update(Student student);
        void Delete(Student student);
    }
}
