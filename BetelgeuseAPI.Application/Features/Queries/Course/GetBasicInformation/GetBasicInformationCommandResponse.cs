using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;

public class GetBasicInformationCommandResponse:ResponseMessageAndSucceeded
{
    public BasicInformationResponseDto Data { get; set; }
}