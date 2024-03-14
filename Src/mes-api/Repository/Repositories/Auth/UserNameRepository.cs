//
//  IUserRepository.cs
//
//  Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
//  Copyright (c) 2024 Barrette Outdoor Living
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Auth;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository.Repositories.Auth;

public class UserNameRepository : IUserNameRepository
{
    private readonly FactelligenceContext _Context;
    private readonly ILogger _Logger;

    public UserNameRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
    {
        _Context = context;
        _Logger = loggerFactory.CreateLogger(nameof(UserNameRepository));
    }

    public int ChangePassword(string userId, string oldPassword, string newPassword)
    {
        return _Context.Database.ExecuteSqlInterpolated($"sp_U_UserName_ChangePassword @userId={userId},@pw={oldPassword},@newPw={newPassword}");
    }

    public int AddUserName(UserName userName)
    {
        _Context.UserNames.AddAsync(userName);
        return _Context.SaveChanges();
    }

    public int DeleteUserName(string userId)
    {
        var userName = _Context.UserNames.SingleOrDefault(u => u.UserId == userId);
        _Context.UserNames.Remove(userName);
        return _Context.SaveChanges();
    }

    public IEnumerable<UserName> GetAllUserNames()
    {
        return _Context.UserNames.ToList();
    }

    public UserName GetUserNameById(string userId)
    {
        return _Context.UserNames
            .Where(u => u.UserId == userId)
            .SingleOrDefault();
    }

    public int UpdateUserName(UserName userName)
    {
        return _Context.Database.ExecuteSqlInterpolated(
                $"@user_id={userName.UserId},@user_desc={userName.UserDesc},@active={userName.Active},@hourly_cost={userName.HourlyCost},@email_address={
                    userName.EmailAddress},@lang_id={userName.LangId},@def_dept_id={userName.DefDeptId},@last_pw_change={userName.LastPwChange},@auth_method={
                    userName.AuthMethod},@def_lab_cd={userName.DefLabCd},@smtp_server={userName.SmtpServer},@pop3_server={userName.Pop3Server},@email_account={
                    userName.EmailAccount},@email_pw={userName.EmailPw},@spare1={userName.Spare1},@spare2={userName.Spare2},@spare3={userName.Spare3},@spare4={
                    userName.Spare4},@last_edit_comment={userName.LastEditAt},@mod_id={userName.ModId}"
            );
    }
}

