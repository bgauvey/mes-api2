using System;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;

namespace BOL.API.Repository.Repositories.Core;

public class EntFileRepository : RepositoryBase<EntFile>, IEntFileRepository
{
    public EntFileRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}
