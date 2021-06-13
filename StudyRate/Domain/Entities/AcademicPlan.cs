using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudyRate.Domain.Entities
{
    public class AcademicPlan : EntityBase
    {
        [ForeignKey("Group")]
        [Display(Name = "Група")]
        public int GroupID { get; set; }
        public Group Group { get; set; }

        [ForeignKey("Subject")]
        [Display(Name = "Предмет")]
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey("Professor")]
        [Display(Name = "Викладач")]
        public int ProfessorID { get; set; }
        public Professor Professor { get; set; }

        [Display(Name = "Години")]
        public int Hours { get; set; }

        [Display(Name = "Курсова робота")]
        public bool CourseWork { get; set; }

        [Display(Name = "Семестр навчання")]
        public int Semester { get; set; }
    }
}
