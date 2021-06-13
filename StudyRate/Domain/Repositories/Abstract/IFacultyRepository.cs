using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IFacultyRepository
    {
        IQueryable<Faculty> GetFaculties();
        int GetFacultiesCount();
        Faculty GetFacultyById(int Id);
        void SaveFaculty(Faculty entity);
    }
}
