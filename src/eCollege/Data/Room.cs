using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Room
    {
        public Room()
        {
            Timetable = new HashSet<Timetable>();
        }

        public int Id { get; set; }
        public string RoomName { get; set; }

        public virtual ICollection<Timetable> Timetable { get; set; }
    }
}
