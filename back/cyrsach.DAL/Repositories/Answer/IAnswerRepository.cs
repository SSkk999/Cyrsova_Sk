using cyrsach.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Repositories.Answer
{
    public interface IAnswerRepository : IGenericRepository<AnswerEntity>
    {
        Task<List<AnswerEntity>> GetByQuestionIdAsync(string questionId);
    }
}
