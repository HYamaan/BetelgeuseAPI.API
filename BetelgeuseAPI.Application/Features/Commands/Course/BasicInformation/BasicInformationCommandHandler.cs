using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;

public class BasicInformationCommandHandler:IRequestHandler<BasicInformationCommandRequest, BasicInformationCommandResponse>
{
    public Task<BasicInformationCommandResponse> Handle(BasicInformationCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}