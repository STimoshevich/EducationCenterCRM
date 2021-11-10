using EducationCenterCRM.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services.Interfaces
{
    public interface ITopicService
    {
        Task<List<TopicDTO>> GetAllAsync();
        Task<IEnumerable<string>> GetAllTitles();
        Task<bool> AddNewAsync(TopicDTO topicRequest);
        Task<bool> DeleteByIdAsync(int id);
        Task<TopicDTO> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, TopicDTO topicRequest);
    }
}
