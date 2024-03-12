using System;
using System.Collections.Generic;

namespace eCollege.Data
{
    public partial class Accounter
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int AccountNum { get; set; }
        public int ReceiptNo { get; set; }
        public int Paid { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
