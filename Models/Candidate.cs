using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Created { get; set; }
    }
}