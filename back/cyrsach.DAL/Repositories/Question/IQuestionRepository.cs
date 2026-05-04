using cyrsach.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Repositories.Question
{
    public interface IQuestionRepository : IGenericRepository<QuestionEntity>
    {
        Task<List<QuestionEntity>> GetByTestIdAsync(string testId);
    }
}
