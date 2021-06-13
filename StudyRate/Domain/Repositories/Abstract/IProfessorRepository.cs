using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IProfessorRepository
    {
        IQueryable<Professor> GetProfessors();
        int GetProfessorsCount();
        Professor GetProfessorById(int Id);
        Professor GetProfessorByEmailPassword(string Email, string Password);
        void SaveProfessor(Professor entity);
    }
}
