using System;

namespace ReliasInterviewApi.Models
{
    public class Interviewee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Created { get; set; }
    }
}