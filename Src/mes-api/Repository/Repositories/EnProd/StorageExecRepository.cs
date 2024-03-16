//
//  entityRepository.cs
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

using BOL.API.Domain.Models.EnProd;
using BOL.API.Repository.Interfaces.EnProd;

namespace BOL.API.Repository.Repositories.EnProd;

public class StorageExecRepository : RepositoryBase<StorageExec>, IStorageExecRepository
{
    public StorageExecRepository(FactelligenceContext context, ILoggerFactory loggerFactory)
         : base(context, loggerFactory)
    {
    }

    public int AddInv(StorageExec entity)
    {
        throw new NotImplementedException();
    }
    public int ReduceInv(StorageExec entity)
    {
        throw new NotImplementedException();
    }
    public int Transfer(StorageExec entity)
    {
        throw new NotImplementedException();
    }
    public int Split(StorageExec entity)
    {
        throw new NotImplementedException();
    }
    public int TransferAndUpdateInv(StorageExec entity)
    {
        throw new NotImplementedException();
    }
    public int GetShortages(StorageExec entity)
    {
        throw new NotImplementedException();
    }
    public int GetInventory(StorageExec entity)
    {
        throw new NotImplementedException();
    }
}
