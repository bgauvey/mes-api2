using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Security;

public interface IGrpNameRepository
{
    IEnumerable<GrpName> GetAllGrpNames();
    GrpName GetGrpNameById(int grpId);
    void UpdateGrpName(GrpName grpName);
    void DeleteGrpName(int grpId);
    void AddGrpName(GrpName grpName);
}

