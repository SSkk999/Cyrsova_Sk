using cyrsach.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cyrsach.DAL.Repositories.Test
{
    public class TestRepository : GenericRepository<TestEntity>, ITestRepository
    {
        public TestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<TestEntity?> GetFullByIdAsync(string id)
        {
            return await _context.Tests
                .Include(t => t.Author)
                .Include(t => t.Questions)
                    .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TestEntity>> GetAllFullAsync()
        {
            return await _context.Tests
                .Include(t => t.Author)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<TestEntity>> GetAllByUserIdAsync(string userId)
        {
            return await _context.Tests
                .Where(t => t.AuthorId == userId)
                .Include(t => t.Author)
                .OrderByDescending(t => t.CreatedDate)
                .ToListAsync();
        }
    }
}
