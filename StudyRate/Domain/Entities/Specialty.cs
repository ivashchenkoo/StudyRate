using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyRate.Domain.Entities
{
    public class Specialty : EntityBase
    {
        [Required]
        [Display(Name = "Назва спеціальності")]
        public string Name { get; set; }

        [ForeignKey("Faculty")]
        [Display(Name = "Факультет")]
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }
    }
}
