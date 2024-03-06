
using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.Auth.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public LoginUserCommandHandler( IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.LoginAccountAsync(_mapper.Map<LoginAccountRequest>(request));
        return response.Data;

    }
}