using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReliasInterviewApi.Models
{
    public class CandidateTest
    {
        [Key]
        public int TestId { get; set; }
        public int CandidateId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public Candidate Candidate { get; set; }
        public List<CandidateTestQuestion> TestQuestions { get; set; }
    }
}
