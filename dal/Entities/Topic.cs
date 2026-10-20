using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_depi_ef_core.dal.Entities
{
    public class Topic
    {
        public int TID { get; set; }
        public string TName { get; set; }

        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
