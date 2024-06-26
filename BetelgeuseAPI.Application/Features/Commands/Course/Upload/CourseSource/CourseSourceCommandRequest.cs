﻿using BetelgeuseAPI.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSource;

public class CourseSourceCommandRequest:IRequest<CourseSourceCommandResponse>
{
    public Guid CourseId { get; set; }
    public Guid SectionId { get; set; }
    public Guid LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsFree { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string? Link { get; set; }
    public CourseUploadSourceType Source { get; set; }
    public CourseUploadFileType? FileType { get; set; }
    public IFormFile? uploadFile { get; set; }
}