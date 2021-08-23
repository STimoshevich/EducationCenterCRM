using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface ITopicService
    {
        Task<List<TopicResponse>> GetAllAsync();
        Task<bool> AddNewAsync(TopicRequest topicRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<TopicResponse> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, TopicRequest topicRequest);
    }
}
