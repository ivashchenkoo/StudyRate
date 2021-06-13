using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IAcademicPlanRepository
    {
        IQueryable<AcademicPlan> GetAcademicPlans();
        int GetAcademicPlansCount();
        AcademicPlan GetAcademicPlanById(int Id);
        void SaveAcademicPlan(AcademicPlan entity);
    }
}
