using AutoMapper;
using EducationCenterCRM.BLL.DTO;
using EducationCenterCRM.BLL.Services.Interfaces;
using EducationCenterCRM.DAL.Entities;
using EducationCenterCRM.DAL.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationCenterCRM.BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly TopicsRepository topicRepository;
        private readonly IMapper mapper;

        public TopicService(TopicsRepository topicRepository, IMapper mapper)
        {
            this.topicRepository = topicRepository;
            this.mapper = mapper;
        }

        public async Task<bool> UpdateAsync(int id, TopicDTO topicRequest)
        {
            var updated = 0;
            if (topicRequest is not null)
            {
                //var newTopic = mapper.Map<Topic>(topicRequest);
                //newTopic.Id = id;
                //updated = await topicRepository.UpdateAsync(newTopic);
            }
            return updated > 0 ? true : false;
        }


        public async Task<TopicDTO> GetByIdAsync(int id)
        {
            //var topic = await topicRepository.GetByPredicateOrDefaulAsync
            //    (predicate: x => x.Id == id,
            //    IsTracking: false);
            //return mapper.Map<TopicDTO>(topic);
            return null;
        }

        public async Task<List<TopicDTO>> GetAllAsync()
        {
            var allTopics = await topicRepository.GetAllAsync();
            return mapper.Map<List<TopicDTO>>(allTopics);
        }

        public async Task<IEnumerable<string>> GetAllTitles()
        {
            return await topicRepository.GetAllTitles();
        }

        public async Task<bool> AddNewAsync(TopicDTO topicRequest)
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
