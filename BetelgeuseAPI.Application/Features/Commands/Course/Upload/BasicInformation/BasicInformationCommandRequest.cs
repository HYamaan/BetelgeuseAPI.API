﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;

public class BasicInformationCommandRequest : IRequest<BasicInformationCommandResponse>
{
    public Guid Language { get; set; }
    public int CourseType { get; set; }
    public string Title { get; set; }
    public string SeoDescription { get; set; }
    public IFormFile Thumbnail { get; set; }
    public IFormFile CoverImage { get; set; }
    public string Description { get; set; }
}