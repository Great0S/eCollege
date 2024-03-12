using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Programs
    {
        public Programs()
        {
            Registeration = new HashSet<Registeration>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }

        public virtual ICollection<Registeration> Registeration { get; set; }
    }
}
