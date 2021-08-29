using MyTeam.Core.Interfaces;
using MyTeam.Core.Models;
using MyTeam.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Infrastructure.Repositories
{
    public class UserRepository : CrudGenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base (dbContext)
        {
         
        }
        public Task Add(User entidade)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entidade)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(User entidade)
        {
            throw new NotImplementedException();
        }
    }
}
