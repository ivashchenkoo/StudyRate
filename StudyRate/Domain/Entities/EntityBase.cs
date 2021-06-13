using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudyRate.Domain.Entities
{
    public class EntityBase
    {
        [Required]
        public int Id { get; set; }
    }
}
