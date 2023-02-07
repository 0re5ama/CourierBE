using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Api.DTO.Security;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Api.Controllers.Security;
[Route("api/security/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IUserService _userService;
    public UserController(IMapper Mapper, IUserService userService)
    {
        _mapper = Mapper;
        _userService = userService;

    }



    [HttpGet]
    public async Task<Response<List<UserResponseDTO>>> GetUsers()
    {
        var listUser = await _userService.GetAsync();
        return new Response<List<UserResponseDTO>>(_mapper.Map<List<UserResponseDTO>>(listUser));
    }


    [HttpPost]
    public async Task<Response<UserRequestDTO>> SaveUser(UserRequestDTO user)
    {
        var saveUser = await _userService.SaveAsync(_mapper.Map<User>(user));
        return new Response<UserRequestDTO>(_mapper.Map<UserRequestDTO>(saveUser),true,"User Successfully Created");
    }

    [HttpGet("{id}")]
    public async Task<Response<UserResponseDTO>> GetUser(Guid id)
    {
        var user = await _userService.GetAsync(id);
        return new Response<UserResponseDTO>(_mapper.Map<UserResponseDTO>(user));
    }

    [HttpPut("{id}")]
    public async Task<Response<UserRequestDTO>> UpdateUser(Guid id, UserRequestDTO user)
    {
        var updateUser = await _userService.UpdateAsync(id, _mapper.Map<User>(user));
        return new Response<UserRequestDTO>(_mapper.Map<UserRequestDTO>(updateUser),true,"User Successfully Updated ");

    }

    [HttpDelete("{id}")]
    public async Task<Response<UserResponseDTO>> DeleteUser(Guid id)
    {
        var deleteUser = await _userService.DeleteAsync(id);
        return new Response<UserResponseDTO>(_mapper.Map<UserResponseDTO>(deleteUser),true,"User SuccessFully Deleted");
    }

}
