using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;

namespace BOL.API.Repository.Repositories.Security;

public class UserGrpLinkRepository : IUserGrpLinkRepository
{
    private readonly FactelligenceContext _Context;
    private readonly ILogger _Logger;

    public UserGrpLinkRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
    {
        _Context = context;
        _Logger = loggerFactory.CreateLogger(nameof(UserNameRepository));
    }
    public void AddUserGrpLink(UserGrpLink UserGrpLink)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserGrpLink(int grpId, string userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserGrpLink> GetAllUserGrpLinks()
    {
        return _Context.UserGrpLinks.ToList();
    }

    public UserGrpLink GetUserGrpLinkById(int grpId, string userId)
    {
        return _Context.UserGrpLinks
            .Where(t => t.GrpId == grpId && t.UserId == userId)
            .SingleOrDefault();
    }


    public IEnumerable<UserGrpLink> GetUserGrpLinkByUserId(string userId)
    {
        return _Context.UserGrpLinks
            .Where(t => t.UserId == userId)
            .ToList();
    }
    public void UpdateUserGrpLink(UserGrpLink UserGrpLink)
    {
        throw new NotImplementedException();
    }
}

