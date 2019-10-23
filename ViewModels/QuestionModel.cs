using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReliasInterviewApi.ViewModels
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public Type Type { get; set; }
        public Level Level { get; set; }
        public string? Answer { get; set; }
        public string Description { get; set; }
    }
}
