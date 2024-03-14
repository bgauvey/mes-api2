using BOL.API.Service;

namespace BOL.API.Authorization.Services;

public interface IAuthorizationService
{
    Task<User> Login(AuthenticateModel authenticateModel);
}

