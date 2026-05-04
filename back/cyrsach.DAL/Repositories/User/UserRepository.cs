using cyrsach.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context)
        { }

        public IQueryable<UserEntity> Users => _context.Users;

       

        public async Task<UserEntity?> GetByNameAsync(string name)
        {
            return await Users
                .FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await Users
                .AnyAsync(u => u.Name == name);
        }

    }
}
