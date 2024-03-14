using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;

namespace BOL.API.Repository.Repositories.Security;

public class GrpNameRepository : IGrpNameRepository
{
    private readonly FactelligenceContext _Context;
    private readonly ILogger _Logger;

    public GrpNameRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
    {
        _Context = context;
        _Logger = loggerFactory.CreateLogger(nameof(UserNameRepository));
    }

    public void AddGrpName(GrpName grpName)
    {
        throw new NotImplementedException();
    }

    public void DeleteGrpName(int grpId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GrpName> GetAllGrpNames()
    {
        return _Context.GrpNames.ToList();
    }

    public GrpName GetGrpNameById(int grpId)
    {
        return _Context.GrpNames.Where(t => t.GrpId == grpId).SingleOrDefault();
    }

    public void UpdateGrpName(GrpName grpName)
    {
        throw new NotImplementedException();
    }
}

