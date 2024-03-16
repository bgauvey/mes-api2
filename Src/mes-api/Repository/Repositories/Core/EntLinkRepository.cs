using System;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;

namespace BOL.API.Repository.Repositories.Core;

public class EntLinkRepository: RepositoryBase<EntLink>, IEntLinkRepository
{
    public EntLinkRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}
