using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;

namespace BOL.API.Repository.Repositories.Security;

public class UserGrpLinkRepository : RepositoryBase<UserGrpLink>, IUserGrpLinkRepository
{
    public UserGrpLinkRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}
