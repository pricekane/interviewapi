using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ReliasInterviewApi.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [MaxLength(100)]
        public string PositionType { get; set; }

        public DateTime Created { get; set; }

        public List<CandidateTest> Tests { get; set; }
    }
}