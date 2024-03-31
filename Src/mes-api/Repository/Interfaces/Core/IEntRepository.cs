using System;
using BOL.API.Domain.Models.Core;

namespace BOL.API.Repository.Interfaces.Core;

public interface IEntRepository : IRepositoryBase<Ent>
{
    public Task<string> GetStatusInfoByUserAsync(int sessionId, string userId);
}

