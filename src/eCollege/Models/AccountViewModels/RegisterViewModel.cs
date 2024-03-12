using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCollege.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "الأسم")]
        public string SName { get; set; }

        [Required]
        [Display(Name = "رقم التسجيل")]
        public string Register_id { get; set; }

        [Required]
        [Display(Name = "نوع الحساب")]
        public string UserRoles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} يجب ان تحتوي على {2} على الاقل.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة السر")]
        [Compare("Password", ErrorMessage = "لاتتطابق كلمة السر.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "الجنس")]
        public string SGender { get; set; }
        
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime? SBirthDate { get; set; }

        [Display(Name = "الديانة")]
        public string SReligon { get; set; }

        [Display(Name = "الجنسية")]
        public string SNationality { get; set; }

        [Display(Name = "العنوان")]
        public string SAddress { get; set; }
        
        [Display(Name = "الصورة")]
        public string SPhoto { get; set; }
        
    }
}
