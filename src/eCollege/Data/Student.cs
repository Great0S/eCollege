using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Student
    {
        public Student()
        {
            Registeration = new HashSet<Registeration>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string RegId { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Religon { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<Registeration> Registeration { get; set; }
    }
}
