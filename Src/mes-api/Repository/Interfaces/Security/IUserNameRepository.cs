using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Security;

public interface IUserNameRepository : IRepositoryBase<UserName>
{
    int ChangePassword(string userId, string oldPassword, string newPassword);
}
