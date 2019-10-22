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

        public Question CreateQuestion(Question question)
        {
            if (_context.Questions.Any(i => i.Text == question.Text))
            {
                return null;
            }

            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }

        public Question UpdateQuestion(Question question)
        {
            var existingQuestion= _context.Questions.FirstOrDefault(i => i.QuestionId == question.QuestionId);

            if (existingQuestion == null)
            {
                return null;
            }

            existingQuestion.Answer = question.Answer;
            existingQuestion.Description = question.Description;
            existingQuestion.Level = question.Level;
            existingQuestion.Type = question.Type;
            existingQuestion.Text = question.Text;

            _context.SaveChanges();
            return question;
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
        Question CreateQuestion(Question question);
        Question UpdateQuestion(Question question);
        IEnumerable<Response> GetResponses();
    }
}