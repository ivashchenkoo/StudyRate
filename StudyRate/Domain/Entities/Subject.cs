using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class Subject : EntityBase
    {
        [Required]
        [Display(Name = "Назва предмету")]
        public string Name { get; set; }
    }
}
