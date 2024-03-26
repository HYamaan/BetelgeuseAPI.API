using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;

public class BasicInformationCommandResponse : ResponseMessageAndSucceeded
{
    public BasicInformationResponseDto Data { get; set; }
}