using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Batch
    {
        public Batch()
        {
            Registeration = new HashSet<Registeration>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string SpecId { get; set; }
        public int Fees { get; set; }

        public virtual ICollection<Registeration> Registeration { get; set; }
        public virtual Fees FeesNavigation { get; set; }
        public virtual Specialization Spec { get; set; }
    }
}
