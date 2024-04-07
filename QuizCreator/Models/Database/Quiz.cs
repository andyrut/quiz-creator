using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizCreator.Models.Database
{
    [PrimaryKey("QuizGuid")]
    public class Quiz
    {
        public Guid QuizGuid { get; set; }

        public string Quizee { get; set; } = string.Empty;

        public DateTime DateTaken { get; set; }

        public List<Response> Responses { get; set; } = new List<Response>();
    }
}
