using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRate.Domain.Entities
{
    public class Admin : EntityBase
    {
        [Display(Name = "Логін")]
        public string Username { get; set; }

        [Display(Name = "Auth_key")]
        public string Auth_key { get; set; }

        [Display(Name = "Пароль")]
        public string Password_hash { get; set; }

        [Display(Name = "Password_reset_token")]
        public string Password_reset_token { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
