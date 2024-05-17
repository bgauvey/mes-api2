using System.Data;
using BOL.API.Domain.Enums;
using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository.Repositories.Security;

public class SessionRepository : RepositoryBase<Sessn>, ISessionRepository
{
    private readonly int _timeZoneBiasValue;

    public SessionRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
    {
        _timeZoneBiasValue = (int)configuration.GetSection("Mes").GetValue(typeof(int), "_timeZoneBiasValue");
    }

    public int Create(ClientType clientType, string clientAddress, ref int sessionId)
    {
        // make explicit SQL Parameter
        var sessionIdParam = new SqlParameter("@session_id", SqlDbType.Int) { Direction = ParameterDirection.Output };
        var dbVersion = new SqlParameter("@db_version", SqlDbType.VarChar, 40) { Direction = ParameterDirection.Output };
        var spVersion = new SqlParameter("@sp_version", SqlDbType.VarChar, 40) { Direction = ParameterDirection.Output };
        var defDataVersion = new SqlParameter("@def_data_version", SqlDbType.VarChar, 40) { Direction = ParameterDirection.Output };

        sessionId = -1;

        var recordsAffected = _Context.Database.ExecuteSqlInterpolated($"sp_I_Session @session_id={
            sessionIdParam} OUT,@client_type={
            clientType},@client_address={
            clientAddress},@reqd_events=NULL,@tz_bias=0,@std_time=0,@time_zone_bias_value={
            _timeZoneBiasValue},@db_version={
            dbVersion} OUT,@sp_version={
            spVersion} OUT,@def_data_version={
            defDataVersion} OUT");

        if (sessionIdParam.Value != null)
            sessionId = (int)sessionIdParam.Value;

        return recordsAffected;
    }

    public async Task<int> Login(int sessionId, string userId, string userPw)
    {
        return await _Context.Database.ExecuteSqlInterpolatedAsync($"sp_U_Session_LogIn @session_id={sessionId}, @user_id={userId}, @user_pw={userPw}");
    }

    public async Task<int> LogOff(int sessionId, string userId, int? EntId)
    {
        DateTime? logoffTime = null;
        return await _Context.Database.ExecuteSqlInterpolatedAsync($"sp_U_Session_LogOff @session_id={sessionId}, @user_id={userId}, @ent_id={EntId}, @logoff_time={logoffTime}");
    }

    public async Task<int> LogOnEnt(int sessionId, string userId, int EntId, int? CurLabCd, int? CurDeptId, double? PctLabToApply)
    {
        DateTime? logonTime = null;
        return await _Context.Database.ExecuteSqlInterpolatedAsync($"sp_U_Session_LogOnEnt @session_id={sessionId}, @user_id={userId}, @ent_id={EntId}, @cur_lab_cd={
            CurLabCd}, @cur_dept_id={CurLabCd}, @pct_lab_to_apply={PctLabToApply},@logon_time={logonTime}");
    }
}

