using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_depi_ef_core.dal.Entities
{
    public class Instructor
    {
        public int InsID { get; set; }
        public string InsName { get; set; }
        public decimal Salary { get; set; }
        public decimal? Bonus { get; set; }
        public string Address { get; set; }
        public decimal? Hour_Rate { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public Department ManagedDepartment { get; set; }

        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();
    }
}
