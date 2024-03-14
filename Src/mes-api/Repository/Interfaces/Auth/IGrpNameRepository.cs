using System;
using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Auth
{
	public interface IGrpNameRepository
	{
        IEnumerable<GrpName> GetAllGrpNames();
        GrpName GetGrpNameById(int grpId);
        void UpdateGrpName(GrpName grpName);
        void DeleteGrpName(int grpId);
        void AddGrpName(GrpName grpName);
    }
}

