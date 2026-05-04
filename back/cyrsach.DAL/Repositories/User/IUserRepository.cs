using cyrsach.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.DAL.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public IQueryable<UserEntity> Users { get; }

        Task<UserEntity?> GetByNameAsync(string name);

        Task<bool> ExistsByNameAsync(string email);
    }
}
