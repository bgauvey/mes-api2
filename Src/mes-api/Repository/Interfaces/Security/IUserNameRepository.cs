using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Security;

public interface IUserNameRepository
{
    IEnumerable<UserName> GetAllUserNames();
    UserName GetUserNameById(string userId);
    int UpdateUserName(UserName userName);
    int DeleteUserName(string userNamed);
    int AddUserName(UserName userName);
}

