using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class Student : EntityBase
    {
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "Ідентифікаційний код")]
        public long IdentificationCode { get; set; }

        [Display(Name = "Номер заліковки")]
        public string GradebookNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Адреса")]
        public string Address { get; set; }

        [ForeignKey("Group")]
        [Display(Name = "Група")]
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
