using QuizCreator.Models.Database;

namespace QuizCreator.Quiz
{
    public class QuizMethods
    {
        #region Private Data Members
        private readonly QuizDbContext context;
        #endregion

        #region Constructors
        public QuizMethods(QuizDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Public Methods
        public Template CreateTemplate()
        {
            var now = DateTime.Now;
            var template = new Template
            {
                DateCreated = now,
                DateModified = now
            };
            var result = context.Templates.Add(template);
            context.SaveChanges();
            return result.Entity;
        }
        #endregion
    }
}
