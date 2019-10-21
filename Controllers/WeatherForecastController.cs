using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReliasInterviewApi.Models;

namespace ReliasInterviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntervieweeController : ControllerBase
    {

        private readonly ILogger<IntervieweeController> _logger;

        public IntervieweeController(ILogger<IntervieweeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Interviewee> Get()
        {
            return  
        }
    }
}
