﻿namespace BetelgeuseAPI.Application.DTOs.Request.Account;

public class ChangePasswordRequest
{
    public string? Email { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
    public string?  ConfirmNewPassword { get; set; }
}