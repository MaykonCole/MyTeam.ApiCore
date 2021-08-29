using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeam.Core.Interfaces
{
    public interface ICrudGenericRepository<T> where T: class
    {
        Task<T> Get(long id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entidade);
        Task Update(T entidade);
        Task Delete(T entidade);
    }
}
