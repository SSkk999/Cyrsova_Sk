
using cyrsach.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace cyrsach.DAL.Repositories.Question
{


    public class QuestionRepository : GenericRepository<QuestionEntity>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<QuestionEntity>> GetByTestIdAsync(string testId)
        {
            return await _context.Questions
                .Where(q => q.TestId == testId)
                .Include(q => q.Answers)
                .ToListAsync();
        }
    }
}
