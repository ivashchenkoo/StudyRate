using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetStudents();
        int GetStudentsCount();
        Student GetStudentById(int Id);
        void SaveStudent(Student entity);
    }
}
