using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using BetelgeuseAPI.Application.Exceptions;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.UpdatePassword
{
    public class UpdatePasswordCommandHandler:IRequestHandler<UpdatePasswordCommandRequest,UpdatePasswordCommandResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UpdatePasswordCommandHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }


        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request,
            CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.ConfirmPassword))
                throw new PasswordChangeFailedException($"Lütfen şifreyi birebir doğrulayınız.");

            var response = await _accountService.UpdatePasswordAsync(request);

            return new UpdatePasswordCommandResponse()
            {
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
