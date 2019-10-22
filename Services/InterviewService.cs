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

        public Candidate GetCandidate(int candidateId)
        {
            return _context.Candidates.FirstOrDefault(i => i.Id == candidateId);
        }

        public Candidate CreateCandidate(Candidate candidate)
        {
            if (_context.Candidates.Any(i => i.FirstName == candidate.FirstName && i.LastName == candidate.LastName))
            {
                return null;
            }

            candidate.Created = DateTime.UtcNow;
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public Candidate UpdateCandidate(Candidate candidate)
        {
            var existingCandidate = _context.Candidates.FirstOrDefault(i => i.Id == candidate.Id);

            if (existingCandidate == null)
            {
                return null;
            }

            existingCandidate.FirstName = candidate.FirstName;
            existingCandidate.LastName = candidate.LastName;
            existingCandidate.PositionType = candidate.PositionType;

            _context.SaveChanges();
            return existingCandidate;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions;
        }

        public Question GetQuestion(int questionId)
        {
            return _context.Questions.FirstOrDefault(i => i.QuestionId == questionId);
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
        Candidate GetCandidate(int candidateId);
        Candidate CreateCandidate(Candidate candidate);
        Candidate UpdateCandidate(Candidate candidate);

        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int questionId);
        Question CreateQuestion(Question question);
        Question UpdateQuestion(Question question);

        IEnumerable<User> GetUsers();
        IEnumerable<Response> GetResponses();
    }
}