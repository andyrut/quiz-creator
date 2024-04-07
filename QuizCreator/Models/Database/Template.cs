using Microsoft.EntityFrameworkCore;

namespace QuizCreator.Models.Database
{
    [PrimaryKey("TemplateGuid")]
    public class Template
    {
        public Guid TemplateGuid { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Quizzer { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = new List<Question>();

        public bool Active { get; set; } = true;

        public bool Public { get; set; } = true;

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}