using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.ViewModels
{
    public class CandidateTestModel
    {
        public int TestId { get; set; }
        public List<TestQuestionModel> TestQuestions { get; set; }
    }
}
