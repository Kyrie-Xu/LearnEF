using MyFrameWork.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MyFrameWork.Models.Models;

namespace MyFrameWork.Dao.Implement
{
    public class StudentDao : IStudentDao
    {
        MyFrameWorkContext context = new MyFrameWorkContext();

        public void Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public List<Student> FindByOptions(Expression<Func<Student,bool>> selector )
        {
            return context.Students.Where(selector).ToList<Student>();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
