using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReliasInterviewApi.Data;
using ReliasInterviewApi.Models;
using ReliasInterviewApi.Services;
using ReliasInterviewApi.ViewModels;

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

        #region Candidate Endpoints
        [HttpGet("candidates")]
        public IEnumerable<Candidate> GetCandidates()
        {
            return _interviewService.GetCandidates();
        }

        [HttpGet("candidate/{id}")]
        public ActionResult<Candidate> GetCandidate(int id)
        {
            var retVal = _interviewService.GetCandidate(id);
            if (retVal == null)
            {
                return NotFound($"No Candidate of id {id} exists");
            }

            return retVal;
        }

        [HttpPost("candidate")]
        public ActionResult<Candidate> CreateCandidate(Candidate candidate)
        {
            return _interviewService.CreateCandidate(candidate);
        }

        [HttpPut("candidate")]
        public ActionResult<Candidate> UpdateCandidate(Candidate candidate)
        {
            return _interviewService.UpdateCandidate(candidate);
        }
        #endregion

        #region Question Endpoints
        [HttpGet("questions")]
        public IEnumerable<Question> GetQuestions()
        {
            return _interviewService.GetQuestions();
        }

        [HttpGet("question/{id}")]
        public ActionResult<Question> GetQuestion(int id)
        {
            var retVal = _interviewService.GetQuestion(id);
            if (retVal == null)
            {
                return NotFound($"No Question of id {id} exists");
            }

            return retVal;
        }

        [HttpPost("questions")]
        public ActionResult<Question> PostQuestion(Question question)
        {
            var retVal = _interviewService.CreateQuestion(question);

            if (retVal == null)
            {
                return BadRequest("Question already exists");
            }

            return retVal;
        }

        [HttpPut("questions")]
        public ActionResult<Question> PutQuestion(Question question)
        {
            var retVal = _interviewService.UpdateQuestion(question);

            if (retVal == null)
            {
                return BadRequest("Question does not exist");
            }

            return retVal;
        }
        #endregion

        #region Test Endpoints
        [HttpGet("test/{testId}")]
        public ActionResult<CandidateTest> GetTest(int testId)
        {
            var retVal = _interviewService.GetTest(testId);
            if (retVal == null)
            {
                return NotFound("No tests found");
            }

            return retVal;
        }

        [HttpPost("test")]
        public ActionResult<CandidateTest> CreateTest(CandidateTest test)
        {
            return _interviewService.CreateTest(test);
        }

        [HttpPost("test/question")]
        public ActionResult AddQuestionToTest(TestQuestionLiteModel testQuestion)
        {
            _interviewService.AddQuestionToTest(testQuestion.TestId, testQuestion.QuestionId);
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpDelete("test/question")]
        public ActionResult RemoveQuestionFromTest(TestQuestionLiteModel testQuestion)
        {
            _interviewService.RemoveQuestionFromTest(testQuestion.TestId, testQuestion.QuestionId);
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPut("test/answer")]
        public ActionResult UpdateTestQuestionAnswer(TestQuestionAnswerModel testQuestionAnswer)
        {
            if (_interviewService.UpdateTestQuestionAnswer(testQuestionAnswer.TestQuestionId, testQuestionAnswer.Answer))
            {
                return StatusCode((int)HttpStatusCode.OK);
            }

            return BadRequest("Unable to save answer");
        }
        #endregion

        [HttpGet("users")]
        public IEnumerable<User> GetUsers()
        {
            return _interviewService.GetUsers();
        }

        [HttpGet("responses")]
        public IEnumerable<Response> GetResponses()
        {
            return _interviewService.GetResponses();
        }
    }
}
