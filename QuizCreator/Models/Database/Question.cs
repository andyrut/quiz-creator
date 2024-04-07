using Microsoft.EntityFrameworkCore;

namespace QuizCreator.Models.Database
{
    [PrimaryKey("QuestionGuid")]
    public class Question
    {
        public Guid QuestionGuid { get; set; }

        public string Text { get; set; } = string.Empty;

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
