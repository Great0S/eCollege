using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace eCollege.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string SName { get; set; }
        public string Register_id { get; set; }
        public string SGender { get; set; }
        public DateTime? SBirthDate { get; set; }
        public string SReligon { get; set; }
        public string SNationality { get; set; }
        public string SAddress { get; set; }
        public string SPhoto { get; set; }
    }
}
