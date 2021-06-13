using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class Department : EntityBase
    {
        [Required]
        [Display(Name = "Назва кафедри")]
        public string Name { get; set; }

        [Display(Name = "Завідуючий кафедри")]
        public string HeadName { get; set; }

        [ForeignKey("Faculty")]
        [Display(Name = "Факультет")]
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
