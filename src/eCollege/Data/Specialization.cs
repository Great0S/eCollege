using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Specialization
    {
        public Specialization()
        {
            Batch = new HashSet<Batch>();
        }

        public string SpecName { get; set; }
        public string DeptartmentId { get; set; }
        public string Course { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
        public virtual Course CourseNavigation { get; set; }
        public virtual Departments Deptartment { get; set; }
    }
}
