using System;
using BOL.API.Domain.Models.Security;

namespace BOL.API.Repository.Interfaces.Auth;

public interface IUserGrpLinkRepository
{
    IEnumerable<UserGrpLink> GetAllUserGrpLinks();
    IEnumerable<UserGrpLink> GetUserGrpLinkByUserId(string userId);
    UserGrpLink GetUserGrpLinkById(int grpId, string userId);
    void UpdateUserGrpLink(UserGrpLink UserGrpLink);
    void DeleteUserGrpLink(int grpId, string userId);
    void AddUserGrpLink(UserGrpLink UserGrpLink);
}

