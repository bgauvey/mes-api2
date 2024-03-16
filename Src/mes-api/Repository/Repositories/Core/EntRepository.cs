using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;

namespace BOL.API.Repository.Repositories.Core;

public class EntRepository : RepositoryBase<Ent>, IEntRepository
{
    public EntRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}
