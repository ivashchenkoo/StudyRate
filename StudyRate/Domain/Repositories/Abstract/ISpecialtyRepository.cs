using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface ISpecialtyRepository
    {
        IQueryable<Specialty> GetSpecialties();
        int GetSpecialtiesCount();
        Specialty GetSpecialtyById(int Id);
        void SaveSpecialty(Specialty entity);
    }
}
