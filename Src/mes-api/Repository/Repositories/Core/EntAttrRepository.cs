using System;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;

namespace BOL.API.Repository.Repositories.Core;

public class EntAttrRepository : RepositoryBase<EntAttr>, IEntAttrRepository
{
    public EntAttrRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }
}


