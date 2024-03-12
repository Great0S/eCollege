using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Subjects
    {
        public Subjects()
        {
            Course = new HashSet<Course>();
            Score = new HashSet<Score>();
        }

        public string Name { get; set; }
        public int Hours { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Score> Score { get; set; }
    }
}
