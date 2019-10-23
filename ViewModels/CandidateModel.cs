using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.ViewModels
{
    public class CandidateModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PositionType { get; set; }

        public DateTime Created { get; set; }

        public List<CandidateTestModel> Tests { get; set; }
    }
}
