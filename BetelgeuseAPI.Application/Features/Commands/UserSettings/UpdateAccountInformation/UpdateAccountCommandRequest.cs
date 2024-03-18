using System;
using System.ComponentModel.DataAnnotations;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
using MediatR;

public class UpdateAccountCommandRequest : IRequest<UpdateAccountCommandResponse>
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Language { get; set; }
    public string? TimeZone { get; set; }
    public string? Currency { get; set; }
    public bool? EmailNews { get; set; }
    
}