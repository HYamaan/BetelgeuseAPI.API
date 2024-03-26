using BetelgeuseAPI.Application.DTOs.Request;
using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;

public class GetExtraInformationCommandResponse : ResponseMessageAndSucceeded
{
    public ExtraInformationResponseDto Data { get; set; }

}