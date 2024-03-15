﻿//
//  IJobExecRepository.cs
//
//  Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
//  Copyright (c) 2024 Barrette Outdoor Living
//
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

using BOL.API.Domain.Models.Prod;

namespace BOL.API.Repository.Interfaces.Prod;

public interface IJobExecRepository : IRepositoryBase<JobExec>
{
    void AddProd(int sessionId, string userId, int entId, double qtyProd,
    int? reasCd, string? lotNo, string? rmLotNo, int? toEntId, string? itemId, int? byproductBomPos,
    string? extRef, bool? applyScalingFactor, string? spare1, string? spare2, string? spare3, string? spare4, int? jobPos);

    void AddProdPostExec(int sessionId, string userId, int entId, double qtyProd,
    string woId, string operId, int seqNo, DateTime shiftStart, int shiftId, string? itemId, int? reasCd,
    string? lotNo, string? rmLotNo, int? toEntId, bool? processed, bool? byproduct, string extRef,
    int? moveStatus, string? spare1, string? spare2, string? spare3, string? spare4);

    void CancelAllJobs(int sessionId, string woId);

    List<object> GetJobQueue(string woId, string itemId);

    List<object> GetQueue(int entId, int? jobState, DateTime? reqdByTime, int? job_Priority, int? maxRows);

}