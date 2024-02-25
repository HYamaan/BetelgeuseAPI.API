using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Token;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using BetelgeuseAPI.Application.DTOs.Request.Account;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.LoginUser;

public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public LoginUserCommandHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _accountService.LoginAccountAsync(_mapper.Map<LoginAccountRequest>(request));
        return _mapper.Map<LoginUserCommandResponse>(response);

    }
} 