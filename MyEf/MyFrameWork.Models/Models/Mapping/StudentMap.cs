using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyFrameWork.Models.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentID);

            // Properties
            this.Property(t => t.StudentName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Student");
            this.Property(t => t.StudentID).HasColumnName("StudentID");
            this.Property(t => t.StudentName).HasColumnName("StudentName");
            this.Property(t => t.ClassID).HasColumnName("ClassID");
        }
    }
}
