using AutoMapper;
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Request.Account;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.ForgetPassword;

    public class ForgetPasswordCommandHandler:IRequestHandler<ForgetPasswordCommandRequest,ForgetPasswordCommandResponse>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public ForgetPasswordCommandHandler( IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }


        public async Task<ForgetPasswordCommandResponse> Handle(ForgetPasswordCommandRequest request, CancellationToken cancellationToken)
        {

        var email = new ForgetPasswordRequest()
            {
                Email = request.Email,
            };

            await _authService.ForgotPassword(email,request.Headers);
            return new ForgetPasswordCommandResponse();
        }
    }