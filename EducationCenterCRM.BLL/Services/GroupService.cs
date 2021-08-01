using EducationCenterCRM.DAL.Infrastructure;
using EducationCenterCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Services.BLL
{
    public class GroupService : IGroupService
    {
        private readonly UnitOfWork unitOfWork;

        public GroupService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Group> GetAll()
        {
            return unitOfWork.groupsRepository.GetAll();
        }
        public Group GetByIdOrDefault(int id, bool includeRelations)
        {
            return unitOfWork.groupsRepository.GetByPredicateOrDefault(group => group.Id == id, includeRelations);
        }



        public void DeleteById(int id)
        {
            if (id > 0)
            {
                var group = unitOfWork.groupsRepository.GetByPredicateOrDefault(x => x.Id == id, includeRelations: false);
                if (group is not null)
                {
                    unitOfWork.groupsRepository.Delete(group);

                    unitOfWork.Save();
                }

            }
        }
        public void AddNew(Group group)
        {
            unitOfWork.groupsRepository.Add(group);
            unitOfWork.Save();
        }

        public void Update(Group editedGroup)
        {
            var oldGroupValue = unitOfWork.groupsRepository.GetByPredicateOrDefault(x => x.Id == editedGroup.Id, includeRelations: true);

            if (oldGroupValue?.Students is not null)
                for (int i = 0; i < oldGroupValue.Students.Count;)
                {
                    var res = editedGroup?.Students?.FirstOrDefault(x => x.Id == oldGroupValue.Students[i].Id);
                    if (res is null)
                        oldGroupValue.Students.Remove(oldGroupValue.Students[i]);
                    else
                        i++;
                }

            editedGroup.Students = oldGroupValue?.Students;


            unitOfWork.groupsRepository.Update(editedGroup);
            unitOfWork.Save();



        }
    }
}
