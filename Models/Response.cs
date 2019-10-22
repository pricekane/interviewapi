using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int CandidateId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
