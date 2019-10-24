using ReliasInterviewApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.ViewModels
{
    public class CandidateTestModel
    {
        public CandidateTestModel()
        {

        }
        
        public CandidateTestModel(CandidateTest testEntity)
        {
            TestId = testEntity.TestId;
            Name = testEntity.Name;
            CandidateId = testEntity.CandidateId;
            Created = testEntity.Created;
            Finished = testEntity.Finished;
            HasQuestions = testEntity.TestQuestions.Any();
        }

        public int TestId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool? HasQuestions { get; set; }
        public int CandidateId { get; set; }
        public bool Finished { get; set; }
        public List<TestQuestionModel> TestQuestions { get; set; }
    }
}
