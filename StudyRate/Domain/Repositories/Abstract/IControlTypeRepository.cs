using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IControlTypeRepository
    {
        IQueryable<ControlType> GetControlTypes();
        int GetControlTypesCount();
        ControlType GetControlTypeById(int Id);
        void SaveControlType(ControlType entity);
    }
}
