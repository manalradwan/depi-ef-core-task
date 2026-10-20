using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_depi_ef_core.dal.Entities
{
    public class Student
    {
        public int SID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }

        public int? SuperId { get; set; }
        public Student Supervisor { get; set; }
        public ICollection<Student> Supervisees { get; set; } = new HashSet<Student>();

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}