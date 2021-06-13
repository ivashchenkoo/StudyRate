using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyRate.Domain.Entities
{
    public class Position : EntityBase
    {
        [Required]
        [Display(Name = "Назва посади")]
        public string Name { get; set; }


        [Display(Name = "Скорочена форма")]
        public string ShortForm { get; set; }
    }
}
