using BOL.API.Domain.Enums;
using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Security;

public interface ISessionRepository: IRepositoryBase<Sessn>
{
    int Create(ClientType clientType, string clientAddress, ref int sessionId);
    Task<int> Login(int sessionId, string userId, string userPw);
    Task<int> LogOff(int sessionId, string userId, int? EntId);
    Task<int> LogOnEnt(int sessionId, string userId, int EntId, int? CurLabCd, int? CurDeptId, double? PctLabToApply);
}
