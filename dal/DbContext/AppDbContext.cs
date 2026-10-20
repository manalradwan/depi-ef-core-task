using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_depi_ef_core.dal.Entities;

namespace task_depi_ef_core.dal.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITI_EFCore_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Topic>().HasKey(t => t.TID);
            modelBuilder.Entity<Course>().HasKey(c => c.CID);
            modelBuilder.Entity<Student>().HasKey(s => s.SID);
            modelBuilder.Entity<Department>().HasKey(d => d.DID);
            modelBuilder.Entity<Instructor>().HasKey(i => i.InsID);

            // Composite Keys
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<CourseInstructor>()
                .HasKey(ci => new { ci.CourseId, ci.InstructorId });

            // Relationships
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student).WithMany(s => s.StudentCourses).HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course).WithMany(c => c.StudentCourses).HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci => ci.Course).WithMany(c => c.CourseInstructors).HasForeignKey(ci => ci.CourseId);
            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci => ci.Instructor).WithMany(i => i.CourseInstructors).HasForeignKey(ci => ci.InstructorId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Topic).WithMany(t => t.Courses).HasForeignKey(c => c.TopicId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department).WithMany(d => d.Students).HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department).WithMany(d => d.Instructors).HasForeignKey(i => i.DepartmentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager).WithOne(i => i.ManagedDepartment).HasForeignKey<Department>(d => d.ManagerId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Supervisor).WithMany(s => s.Supervisees).HasForeignKey(s => s.SuperId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}


