using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReliasInterviewApi.Data;
using ReliasInterviewApi.Models;

namespace ReliasInterviewApi.Services
{
    public class InterviewService : IInterviewService
    {

        private readonly Context _context;

        public InterviewService(Context context)
        {
            _context = context;
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _context.Candidates;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions;
        }
        public IEnumerable<Response> GetResponses()
        {
            return _context.Responses;
        }
    }

    public interface IInterviewService
    {
        IEnumerable<Candidate> GetCandidates();
        IEnumerable<User> GetUsers();
        IEnumerable<Question> GetQuestions();
        IEnumerable<Response> GetResponses();
    }
}