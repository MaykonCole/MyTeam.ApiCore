using MyTeam.Core.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeam.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateNewUser(AppUserViewModel userViewModel);

        Task<List<AppUserViewModel>> GetAllUsers();

        Task<AppUserViewModel> GetUserById(long userId);

        Task<bool> UpdateUser(long userId,UpdateUserViewModel userViewModel);

        Task<bool> DeleteUser(long userId);
    }
}
