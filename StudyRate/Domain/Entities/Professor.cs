using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class Professor : EntityBase
    {
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Position")]
        [Display(Name = "Посада")]
        public int PositionID { get; set; }
        public Position Position { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } 
        
        [Required]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Кафедра")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
