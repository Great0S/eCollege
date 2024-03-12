using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Employees
    {
        public Employees()
        {
            Accounter = new HashSet<Accounter>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }

        public virtual ICollection<Accounter> Accounter { get; set; }
        public virtual Departments DepartmentNavigation { get; set; }
        public virtual Jobs JobNavigation { get; set; }
    }
}
