using Microsoft.EntityFrameworkCore;

namespace QuizCreator.Models.Database
{
    [PrimaryKey("ResponseGuid")]
    public class Response
    {
        public Guid ResponseGuid { get; set; }

        public Guid AnswerGuid { get; set; }
    }
}