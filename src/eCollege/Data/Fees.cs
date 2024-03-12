using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Fees
    {
        public Fees()
        {
            Batch = new HashSet<Batch>();
        }

        public int FeeNo { get; set; }
        public decimal RegisterFee { get; set; }
        public decimal StudyFee { get; set; }
        public decimal? Total { get; set; }
        public decimal? YearTotal { get; set; }

        public virtual ICollection<Batch> Batch { get; set; }
    }
}
