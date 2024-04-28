using Microsoft.EntityFrameworkCore;
using QuizCreator.Models.Database;

namespace QuizCreator.Quiz
{
    public class QuizMethods
    {
        #region Private Data Members
        private readonly QuizDbContext context;

        private const int MaxQuestions = 20;

        private const int NumAnswers = 4;
        #endregion

        #region Constructors
        public QuizMethods(QuizDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        public Guid CreateTemplate()
        {
            var now = DateTime.Now;

            var questions = new List<Question>();
            for (int q = 0; q < MaxQuestions; q++)
                questions.Add(new Question());
            foreach (var question in questions)
            {
                for (int a = 0; a < NumAnswers; a++)
                    question.Answers.Add(new Answer());
                question.Answers.First().Correct = true;
            }

            var template = new Template
            {
                Name = string.Empty,
                Description = string.Empty,
                Questions = questions,
                DateCreated = now,
                DateModified = now
            };
            var result = context.Templates.Add(template);
            context.SaveChanges();
            return result.Entity.TemplateGuid;
        }

        public Template? GetTemplate(Guid templateGuid)
        {
            var template = context.Templates.Include(x => x.Questions).ThenInclude(x => x.Answers).FirstOrDefault(x => x.TemplateGuid == templateGuid);
            return template;
        }

        public void UpdateTemplate(Template template)
        {
            context.Templates.Update(template);
            context.SaveChanges();
        }
        #endregion
    }
}
