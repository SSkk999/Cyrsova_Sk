using cyrsach.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Repositories.Test
{
    public interface ITestRepository : IGenericRepository<TestEntity>
    {
        Task<TestEntity?> GetFullByIdAsync(string id);
        Task<List<TestEntity>> GetAllFullAsync();
        Task<List<TestEntity>> GetAllByUserIdAsync(string userId);
    }
}
