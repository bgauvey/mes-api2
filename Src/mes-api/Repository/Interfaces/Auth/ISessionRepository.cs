using System;
using BOL.API.Domain.Enums;

namespace BOL.API.Repository.Interfaces.Auth
{
	public interface ISessionRepository
	{
        Task<int> CreateAsync(ClientType clientType, string clientAddress, ref int sessionId);
		Task<int> LoginAsync(int sessionId, string userId, string userPw);
		Task<int> DeleteAsync(int sessionId);

        int Create(ClientType clientType, string clientAddress, ref int sessionId);
        int Login(int sessionId, string userId, string userPw);
        int Delete(int sessionId);
    }
}

