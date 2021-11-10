using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.DAL.Filteres.GroupFilters
{
    public class StatusSpecification : ISpecification<Group>
    {
        private GroupStatus? groupStatus;

        public StatusSpecification(GroupStatus? groupStatus)
        {
            this.groupStatus = groupStatus;
        }

        public Expression<Func<Group, bool>> ApplyFilter()
        {
            return x=>x.Status == this.groupStatus;
        }

        public bool IsSatisfied(Group item)
        {
            return item.Status == this.groupStatus;
        }
    }
}
