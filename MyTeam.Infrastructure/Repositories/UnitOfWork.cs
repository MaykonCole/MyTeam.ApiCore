using MyTeam.Core.Interfaces;
using MyTeam.Infrastructure.Data;
using System;

namespace MyTeam.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext,
                            IUserRepository UserRepository)
        {
            _dbContext = applicationDbContext;
            Users = UserRepository;
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}