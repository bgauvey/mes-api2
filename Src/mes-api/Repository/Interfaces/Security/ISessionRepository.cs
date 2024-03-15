using BOL.API.Domain.Enums;
using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Security;

public interface ISessionRepository: IRepositoryBase<Sessn>
{
    int Create(ClientType clientType, string clientAddress, ref int sessionId);
    int Login(int sessionId, string userId, string userPw);
}
