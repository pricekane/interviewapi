using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReliasInterviewApi.Models
{
    public class CandidateTest
    {
        [Key]
        public int TestId { get; set; }
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
        public List<CandidateTestQuestion> TestQuestions { get; set; }
    }
}
