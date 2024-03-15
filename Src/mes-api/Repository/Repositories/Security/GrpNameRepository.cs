using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;

namespace BOL.API.Repository.Repositories.Security;

public class GrpNameRepository : RepositoryBase<GrpName>, IGrpNameRepository
{
    public GrpNameRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}
