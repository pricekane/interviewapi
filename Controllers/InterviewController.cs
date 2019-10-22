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
    public class InterviewController : ControllerBase
    {

        private readonly ILogger<InterviewController> _logger;
        private readonly IInterviewService _interviewService;

        public InterviewController(ILogger<InterviewController> logger, IInterviewService interviewService)
        {
            _logger = logger;
            _interviewService = interviewService;
        }

        [HttpGet("candidates")]
        public IEnumerable<Candidate> GetCandidates()
        {
            return _interviewService.GetCandidates();
        }

        [HttpGet("users")]
        public IEnumerable<User> GetUsers()
        {
            return _interviewService.GetUsers();
        }

        [HttpGet("questions")]
        public IEnumerable<Question> GetQuestions()
        {
            return _interviewService.GetQuestions();
        }

        [HttpGet("responses")]
        public IEnumerable<Response> GetResponses()
        {
            return _interviewService.GetResponses();
        }

        [HttpPost("questions")]
        public ActionResult<Question> PostResponse(Question question)
        {
            return _interviewService.UpdateQuestion(question);
        }
    }
}
