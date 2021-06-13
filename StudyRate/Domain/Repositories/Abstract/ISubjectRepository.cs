using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface ISubjectRepository
    {
        IQueryable<Subject> GetSubjects();
        int GetSubjectsCount();
        Subject GetSubjectById(int Id);
        void SaveSubject(Subject entity);
    }
}
