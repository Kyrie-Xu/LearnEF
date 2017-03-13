using MyFrameWork.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFrameWork.EF;
using System.Linq.Expressions;

namespace MyFrameWork.Dao.Implement
{
    public class StudentDao : IStudentDao
    {
        MyFrameWorkEntities context = new MyFrameWorkEntities();

        public void Add(MyFrameWork.EF.Student student)
        {
            context.Student.Add(student);
            context.SaveChanges();
        }

        public List<MyFrameWork.EF.Student> FindByOptions(Expression<Func<Student,bool>> selector )
        {
            return context.Student.Where(selector).ToList<Student>();
        }

        public void Update(MyFrameWork.EF.Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(MyFrameWork.EF.Student student)
        {
            throw new NotImplementedException();
        }
    }
}
