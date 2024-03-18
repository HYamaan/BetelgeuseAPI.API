using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Exception = System.Exception;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }


    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _accountService.CreateAccountAsync(request);
            return new CreateUserCommandResponse()
            {
                Succeeded = response.Succeeded,
                Message = response.Message,
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}