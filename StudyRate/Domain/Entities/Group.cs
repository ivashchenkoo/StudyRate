using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class Group : EntityBase
    {
        [Required]
        [Display(Name = "Назва групи")]
        public string Name { get; set; }

        [Display(Name = "Рік вступу")]
        public int YearOfEntering { get; set; }

        [ForeignKey("Specialty")]
        [Display(Name = "Спеціальність")]
        public int SpecialtyID { get; set; }
        public Specialty Specialty { get; set; }
    }
}
