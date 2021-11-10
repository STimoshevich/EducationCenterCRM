using EducationCenterCRM.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterCRM.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : Controller
    {
        private readonly ITopicService topicService;

        public TopicsController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        [HttpGet("alltitles")]
        public async Task<IActionResult> GetAllTitlesAsync()
        {
            return Ok(await topicService.GetAllTitles());
        }
    }
}
