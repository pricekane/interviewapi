using System.ComponentModel.DataAnnotations;
using ReliasInterviewApi.ViewModels;

namespace ReliasInterviewApi.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public Type Type { get; set; }
        public Level Level { get; set; }
        public string? Answer { get; set; }
        public string Description { get; set; }

        public QuestionModel CreateModel()
        {
            return new QuestionModel()
            {
                QuestionId = QuestionId,
                Answer = Answer,
                Description = Description,
                Level = (int)Level,
                Type = (int)Type,
                Text = Text
            };
        }
    }
}
