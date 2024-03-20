using BOL.API.Service.Models;

namespace BOL.API.Service.Interfaces;

public interface IAuthorizationService
{
    Task<User> Login(AuthenticateModel authenticateModel);
    Task<int> LogOff(int? EntId);
    Task<int> LogOnEnt(int EntId, int? CurLabCd, int? CurDeptId, double? PctLabToApply);
    Task<int> ChangePassword(string userId, string oldPassword, string newPassword);
}

