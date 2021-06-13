using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyRate.Domain.Entities;

namespace StudyRate.Domain.Repositories.Abstract
{
    public interface IGroupRepository
    {
        IQueryable<Group> GetGroups();
        int GetGroupsCount();
        Group GetGroupById(int Id);
        void SaveGroup(Group entity);
    }
}
