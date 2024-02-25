using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.ChangePassword;

public class ChangePasswordCommandHandler:IRequestHandler<ChangePasswordCommandRequest,ChangePasswordCommandResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public ChangePasswordCommandHandler(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        var response =await _accountService.ChangePassword(_mapper.Map<ChangePasswordRequest>(request));

        return new ChangePasswordCommandResponse()
        {
            Succeeded = response.Succeeded,
            Message = response.Message
        };
    }
}