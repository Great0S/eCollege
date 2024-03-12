using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Course
    {
        public Course()
        {
            Specialization = new HashSet<Specialization>();
        }

        public decimal Id { get; set; }
        public string Subject { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Specialization> Specialization { get; set; }
        public virtual Subjects SubjectNavigation { get; set; }
    }
}
