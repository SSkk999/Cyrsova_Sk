using cyrsach.DAL.Entities;
using Microsoft.EntityFrameworkCore;



namespace cyrsach.DAL.Repositories.Answer
{
    public class AnswerRepository : GenericRepository<AnswerEntity>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<AnswerEntity>> GetByQuestionIdAsync(string questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }
    }
}
