using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_depi_ef_core.dal.Entities
{
    public class Department
    {
        public int DID { get; set; }
        public string DName { get; set; }

        public int? ManagerId { get; set; }
        public Instructor Manager { get; set; }
        public DateTime? HireDate { get; set; }

        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
