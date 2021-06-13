using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class Mark : EntityBase
    {
        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Студент")]
        public int StudentID { get; set; }
        public Student Student { get; set; }

        [Required]
        [ForeignKey("Subject")]
        [Display(Name = "Предмет")]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        [Required]
        [ForeignKey("ControlType")]
        [Display(Name = "Тип контролю")]
        public int ControlTypeID { get; set; }
        public ControlType ControlType { get; set; }

        [Required]
        [Display(Name = "Оцінка")]
        public int Score { get; set; }

        [Required]
        [Display(Name = "Семестр")]
        public int Semester { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
