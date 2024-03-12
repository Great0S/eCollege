using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Timetable
    {
        public decimal SchId { get; set; }
        public decimal CourseId { get; set; }
        public int RoomId { get; set; }
        public string Teacher { get; set; }
        public string Day { get; set; }
        public TimeSpan Time { get; set; }
        public string Month { get; set; }

        public virtual Room Room { get; set; }
    }
}
