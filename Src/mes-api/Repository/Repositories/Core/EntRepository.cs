using System;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Repositories;

namespace BOL.API.Repository.Core;

public class EntRepository : RepositoryBase<Ent>, IEntRepository
{
    public EntRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}
