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
        public ActionResult<CandidateModel> GetCandidate(int id)
        {
            var candidateEntity = _interviewService.GetCandidate(id);
            if (candidateEntity == null)
            {
                return NotFound($"No Candidate of id {id} exists");
            }

            var retVal = new CandidateModel()
            {
                Id = id,
                FirstName = candidateEntity.FirstName,
                LastName = candidateEntity.LastName,
                PositionType = candidateEntity.PositionType,
                Created = candidateEntity.Created
            };

            if (candidateEntity.Tests.Any())
            {
                retVal.Tests = new List<CandidateTestModel>();
                foreach (var test in candidateEntity.Tests)
                {
                    retVal.Tests.Add(new CandidateTestModel(test));
                }
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
        public ActionResult<QuestionModel> PostQuestion(QuestionModel question)
        {
            var retVal = _interviewService.CreateQuestion(question);

            if (retVal == null)
            {
                return BadRequest("Question already exists");
            }

            return retVal.CreateModel();
        }

        [HttpPut("questions")]
        public ActionResult<QuestionModel> PutQuestion(QuestionModel question)
        {
            var retVal = _interviewService.UpdateQuestion(question);

            if (retVal == null)
            {
                return BadRequest("Question does not exist");
            }

            return retVal.CreateModel();
        }
        #endregion

        #region Test Endpoints
        [HttpGet("test/{testId}")]
        public ActionResult<CandidateTestModel> GetTest(int testId)
        {
            var testEntity = _interviewService.GetTest(testId);

            if (testEntity == null)
            {
                return NotFound("No tests found");
            }

            var retVal = new CandidateTestModel(testEntity);

            if (!testEntity.TestQuestions.Any())
            {
                return retVal;
            }

            retVal.TestQuestions = new List<TestQuestionModel>();
            testEntity.TestQuestions.ForEach(i =>
            {
                retVal.TestQuestions.Add(new TestQuestionModel()
                {
                    TestQuestionId = i.TestQuestionsId,
                    Answer = i.Answer,
                    Question = new QuestionModel()
                    {
                        QuestionId = i.QuestionId,
                        Answer = i.Question.Answer,
                        Description = i.Question.Description,
                        Level = (int)i.Question.Level,
                        Text = i.Question.Text,
                        Type = (int)i.Question.Type
                    }
                });
            });

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

        [HttpDelete("test/{testId}/question/{questionId}")]
        public ActionResult RemoveQuestionFromTest(int testId, int questionId)
        {
            _interviewService.RemoveQuestionFromTest(testId, questionId);
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

        [HttpPut("test/{testId}/finish")]
        public ActionResult FinishTest(int testId)
        {
            var success = _interviewService.FinishTest(testId);

            if (success)
            {
                return StatusCode((int) HttpStatusCode.OK);
            }

            return NotFound("No such test");
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
