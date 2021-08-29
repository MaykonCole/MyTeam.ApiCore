using AutoMapper;
using MyTeam.Core.Interfaces;
using MyTeam.Core.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeam.Core.Services.User
{
    public class UserService : IUserService
    {

        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateNewUser(AppUserViewModel userViewModel)
        {
            if (userViewModel != null)
            {
                var newUser = _mapper.Map<MyTeam.Core.Models.User>(userViewModel);
                newUser.CriadoEm = DateTime.Now;
                newUser.CriadoPor = 0;
                await _unitOfWork.Users.Add(newUser);

                var result = _unitOfWork.Complete();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUser(long userId)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.Users.Get(userId);
                if (user != null)
                {
                   await _unitOfWork.Users.Delete(user);
                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<List<AppUserViewModel>> GetAllUsers()
        {
            var userList = await _unitOfWork.Users.GetAll();
            var userListResp = _mapper.Map<List<AppUserViewModel>>(userList);
            return userListResp;
        }

        public async Task<AppUserViewModel> GetUserById(long userId)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.Users.Get(userId);
                if (user != null)
                {
                    var userResp = _mapper.Map<AppUserViewModel>(user);
                    return userResp;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUser(long userId, UpdateUserViewModel userViewModel)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.Users.Get(userId);
                if (user != null)
                {
                    user.Login = userViewModel.Login;
                    user.Email = userViewModel.Email;
                    user.AtualizadoEm = DateTime.Now;
                    user.AtualizadoPor = userViewModel.Id;
                    await _unitOfWork.Users.Update(user);

                    var result = _unitOfWork.Complete();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
