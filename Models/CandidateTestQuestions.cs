using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReliasInterviewApi.Models
{
    public class CandidateTestQuestion
    {
        [Key]
        public int TestQuestionsId { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }

        public CandidateTest Test { get; set; }
        public Question Question { get; set; }
    }
}
