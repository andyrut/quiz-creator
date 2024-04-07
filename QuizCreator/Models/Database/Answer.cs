using Microsoft.EntityFrameworkCore;

namespace QuizCreator.Models.Database
{
    [PrimaryKey("AnswerGuid")]
    public class Answer
    {
        public Guid AnswerGuid { get; set; }

        public bool Correct { get; set; } = false;

        public string Text { get; set; } = string.Empty;
    }
}