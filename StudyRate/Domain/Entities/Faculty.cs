using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StudyRate.Domain.Entities
{
    public class Faculty : EntityBase
    {
        [Required]
        [Display(Name = "Назва факультету")]
        public string Name { get; set; }

        [Display(Name = "Абревіатура")]
        public string ShortForm { get; set; }


        [Display(Name = "Декан")]
        public string Dean { get; set; }

        public List<Department> Departments { get; set; }
    }
}
