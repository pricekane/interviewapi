using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReliasInterviewApi.Data;
using ReliasInterviewApi.Models;
using ReliasInterviewApi.Services;

namespace ReliasInterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntervieweeController : ControllerBase
    {

        private readonly ILogger<IntervieweeController> _logger;
        private readonly IInterviewService _interviewService;

        public IntervieweeController(ILogger<IntervieweeController> logger, IInterviewService interviewService)
        {
            _logger = logger;
            _interviewService = interviewService;
        }

        [HttpGet]
        public IEnumerable<Interviewee> Get()
        {
            return _interviewService.GetInterviewees();  
        }
    }
}
