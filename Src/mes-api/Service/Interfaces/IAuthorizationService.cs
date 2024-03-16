using BOL.API.Service.Models;

namespace BOL.API.Service.Interfaces;

public interface IAuthorizationService
{
    Task<User> Login(AuthenticateModel authenticateModel);
}

