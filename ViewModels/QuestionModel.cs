using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReliasInterviewApi.Models;

namespace ReliasInterviewApi.ViewModels
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public string? Answer { get; set; }
        public string Description { get; set; }

        public Question CreateEntity()
        {
            return new Question()
            {
                QuestionId = QuestionId,
                Answer = Answer,
                Description = Description,
                Level = (Level)Level,
                Type = (Models.Type)Type,
                Text = Text
            };
        }
    }
}
