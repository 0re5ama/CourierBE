using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductTracking.Api.DTO;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenClaimsService _tokenService;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    public AuthController(IAuthService accountService, ITokenClaimsService tokenService, IMapper mapper, ICurrentUserService currentUserService)
    {
        _authService = accountService;
        _tokenService = tokenService;
        _mapper = mapper;
        _currentUserService = currentUserService;

    }
    /// <summary>
    /// Authenticates User
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("authenticate")]

    public async Task<IActionResult> AuthenticateAsync(UserCredDTO request)
    {
        try
        {
            var user = await _authService.AuthenticateAsync(request.Email, request.Password);
            var token = await _tokenService.GetTokenAsync(user);
            return Ok(new TokenResponse(_mapper.Map<UserDTO>(user), token, "Successfully logged in"));
        }
        catch (Exception ex)
        {
            return Unauthorized(new TokenResponse(null, null, "Invalid login", false));

        }

    }

    /// <summary>
    /// Registers User
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(UserRegisterDTO request)
    {
        return Ok(await _authService.RegisterAsync(_mapper.Map<User>(request)));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserAsync()
    {
        return Ok(new UserInfo(_currentUserService.UserInfo));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserAsync(Guid Id)
    {
        return Ok(await _authService.GetUserAsync(Id));
    }
}
