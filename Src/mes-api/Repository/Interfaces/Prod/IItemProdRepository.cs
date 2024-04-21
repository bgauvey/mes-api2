//
// IItemProdRepository.cs
//
// Author:
//       Bill Gauvey <Bill.Gauvey@barretteoutdoorliving.com>
//
// Copyright (c) 2024 Barrette Outdoor Living
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using BOL.API.Domain.Models.Prod;

namespace BOL.API.Repository.Interfaces.Prod
{
	public interface IItemProdRepository : IRepositoryBase<ItemProd>
	{

        Task<string> IsSameProducedAsync(string woId, string operId, int? seqNo, string? itemId);

        Task<int> RejectProdAsync(int sessionId, int oldRowId, double splitQtyProd, string newWoId, string newOperId, int? newSeqNo, DateTime? newShiftStartLocal, string newItemId, string newLotNo,
            string newRmLotNo, string newSublotNo, string newRmSublotNo, int? newReasCd, string newUserId, int? newEntId, int? newShiftId, int? newToEntId, double? splitQtyProdErp, bool splitProcessedFlag, bool splitByproductFlag);

        Task<int> SetCurLotDataAsync(int entId, int jobPos, int bomPos, string curItemId, string curLotNo, string curSublotNo, int curReasCd, int curStorageEntId, bool curUpdateInv, bool curBackflush);

    }
}

