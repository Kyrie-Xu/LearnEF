using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MyFrameWork.Models.Models.Mapping;

namespace MyFrameWork.Models.Models
{
    public partial class MyFrameWorkContext : DbContext
    {
        static MyFrameWorkContext()
        {
            Database.SetInitializer<MyFrameWorkContext>(null);
        }

        public MyFrameWorkContext()
            : base("Name=MyFrameWorkContext")
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClassMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
