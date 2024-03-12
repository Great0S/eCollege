using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCollege.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Reg_id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تذكر بياناتي ؟")]
        public bool RememberMe { get; set; }
    }
}
