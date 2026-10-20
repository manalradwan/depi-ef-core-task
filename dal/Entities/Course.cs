using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace task_depi_ef_core.dal.Entities
{
    public class Course
    {
        public int CID { get; set; }
        public string CName { get; set; }
        public int Duration { get; set; }
        public string Desc { get; set; }

        public int? TopicId { get; set; }
        public Topic Topic { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();

    }
}


