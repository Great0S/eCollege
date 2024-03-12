using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
            Specialization = new HashSet<Specialization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Specialization> Specialization { get; set; }
    }
}
