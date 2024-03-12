using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Registeration
    {
        public Registeration()
        {
            Score = new HashSet<Score>();
        }

        public string RegisterId { get; set; }
        public int StdId { get; set; }
        public string Batch { get; set; }
        public int ProgramId { get; set; }
        public string SpecId { get; set; }
        public string Recommend { get; set; }
        public string UniId { get; set; }
        public string SubjectType { get; set; }
        public string MedExam { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public string Semester { get; set; }
        public string Docs { get; set; }

        public virtual ICollection<Score> Score { get; set; }
        public virtual Batch BatchNavigation { get; set; }
        public virtual Programs Program { get; set; }
        public virtual Student Std { get; set; }
    }
}
