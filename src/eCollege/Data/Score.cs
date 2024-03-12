using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Score
    {
        public string Id { get; set; }
        public string RegId { get; set; }
        public string Semester { get; set; }
        public string SubId { get; set; }
        public double? Hours { get; set; }
        public string Grade { get; set; }
        public string Term_Grade { get; set; }

        public virtual Registeration Reg { get; set; }
        public virtual Subjects Sub { get; set; }
    }
}
