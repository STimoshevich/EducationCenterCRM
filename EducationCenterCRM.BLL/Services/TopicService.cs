using AutoMapper;
using EducationCenterCRM.BLL.Contracts.V1.RequestModels;
using EducationCenterCRM.BLL.Contracts.V1.ResponseModels;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Interfaces;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly IRepository<Topic> topicRepository;
        private readonly IMapper mapper;

        public TopicService(IRepository<Topic> topicRepository, IMapper mapper)
        {
            this.topicRepository = topicRepository;
            this.mapper = mapper;
        }

        public  async Task<bool> UpdateAsync(int id, TopicRequest topicRequest)
        {
            var updated = 0;
            if (topicRequest is not null)
            {
                var newTopic = mapper.Map<Topic>(topicRequest);
                newTopic.Id = id;
                updated = await topicRepository.UpdateAsync(newTopic);
            }
            return updated > 0 ? true : false;
        }

    
        public  async Task<TopicResponse> GetByIdAsync(int id)
        {
            var topic = await topicRepository.GetByPredicateOrDefaulAsync
                (predicate: x => x.Id == id,
                IsTracking: false);
            return mapper.Map<TopicResponse>(topic);
        }

        public async Task<List<TopicResponse>> GetAllAsync()
{
            var allTopics = await topicRepository.GetAllAsync();
            return mapper.Map<List<TopicResponse>>(allTopics);
        }

        public async Task<bool> AddNewAsync(TopicRequest topicRequest)
        {
            var added = 0;
            if (topicRequest is not null)
            {
                var newTopic = mapper.Map<Topic>(topicRequest);
                added = await topicRepository.AddAsync(newTopic);
            }
            return added > 0 ? true : false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var deleted = await topicRepository.DeleteAsync(id);
            return deleted > 0 ? true : false;
        }
    }
}
