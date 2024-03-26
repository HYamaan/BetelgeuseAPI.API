﻿using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class BasicInformationResponseDto
{
    public Languages Language { get; set; }
    public int CourseType { get; set; }
    public string Title { get; set; }
    public string SeoDescription { get; set; }
    public string Thumbnail { get; set; }
    public string CoverImage { get; set; }
    public string Description { get; set; }
}