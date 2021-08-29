using Microsoft.AspNetCore.Mvc;
using MyTeam.Core.Interfaces;
using MyTeam.Core.ViewModels.User;
using MyTeam.WebApiCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeam.WebApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retorna todos usuários cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _userService.GetAllUsers();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                var resp = new ApiResponse { Status = false, Message = ex.Message, Data = null };
                return BadRequest(resp);
            }
        }

        /// <summary>
        /// Retorna um usuário de acordo o seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetUserBtId/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _userService.GetUserById(id);
                if (usuario == null)
                {
                    var resp = new ApiResponse { Status = true, Message = "Usuário com ID : " + id + " não foi localizado.", Data = usuario };
                    return NotFound(resp);
                }
                   
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                var resp = new ApiResponse { Status = false, Message = ex.Message, Data = null };
                return BadRequest(resp);
            }
        }

        /// <summary>
        /// Cria um novo Usuário
        /// </summary>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post (AppUserViewModel userViewModel)
        {
            try
            {
                var userCreated = await _userService.CreateNewUser(userViewModel);

                if (userCreated)
                {
                    var resp = new ApiResponse { Status = true, Message = "Usuário criado com sucesso.", Data = null };
                    return Ok(resp);
                }
                else
                {
                    var resp = new ApiResponse { Status = false, Message = "Houve algum erro ao criar um novo usuário.", Data = null };
                    return BadRequest(resp);
                }
            }
            catch (Exception ex)
            {
                var resp = new ApiResponse { Status = false, Message = ex.Message, Data = userViewModel };
                return BadRequest(resp);
            }
        }

        /// <summary>
        /// Atualiza um Usuário de acorodo o seu ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userViewModel"></param>
        /// <returns></returns>
        [HttpPut("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int userId, UpdateUserViewModel userViewModel)
        {
            var userCreated = await _userService.UpdateUser(userId, userViewModel);

            if (userCreated)
            {
                var resp = new ApiResponse { Status = true, Message = "Usuário " + userViewModel.Login + " atualizado com sucesso.", Data = null };
                return Ok(resp);
            }
            else
            {
                var resp = new ApiResponse { Status = false, Message = "Não foi possivel atualizar o Usuário.", Data = userViewModel };
                return BadRequest(resp);
            }
        }

        /// <summary>
        /// Exclui um Usuário de acorodo o seu ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(long userId)
        {
            var userCreated = await _userService.DeleteUser(userId);

            if (userCreated)
            {
                var resp = new ApiResponse { Status = true, Message = "Usuário excluído com sucesso.", Data = null };
                return Ok(resp);
            }
            else
            {
                var resp = new ApiResponse { Status = false, Message = "Não foi possivel excluir o Usuário.", Data = null };
                return BadRequest(resp);
            }
        }
    }
}
