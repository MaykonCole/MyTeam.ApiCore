using MyTeam.Core.Interfaces;
using MyTeam.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeam.Infrastructure.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DatabaseInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedSampleData()
        {
            await _dbContext.Database.EnsureCreatedAsync().ConfigureAwait(false);

            if (!_dbContext.Users.Any())
            {
                var testUser1 = new User
                {
                    Login = "Maykon",
                    Senha = "teste123",
                    Email = "maykontaio@hotmial.com",
                    ResponsavelTime = true,
                    CriadoEm = DateTime.Now,
                    CriadoPor = 0,
                    Ativo = true

                };

                var testUser2 = new User
                {
                    Login = "Isabela",
                    Senha = "teste456",
                    Email = "bellaisa72@hotmail.com",
                    ResponsavelTime = false,
                    CriadoEm = DateTime.Now,
                    CriadoPor = 0,
                    Ativo = true
                };

                _dbContext.Users.Add(testUser1);
                _dbContext.Users.Add(testUser2);

                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
