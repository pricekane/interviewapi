using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.ViewModels
{
    public class TestQuestionModel
    {
        public int TestQuestionId { get; set; }
        public string Answer { get; set; }
        public QuestionModel Question { get; set; }
    }
}
