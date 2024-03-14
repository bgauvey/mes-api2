using System;
using System.ComponentModel.DataAnnotations;
using BOL.API.Domain.Enums;

namespace BOL.API.Service;

public class AuthenticateModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public ClientType ClientType { get; set; }
}

