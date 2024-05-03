//
// GrpEntLinkService.cs
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
using BOL.API.Domain.Models.Security;
using BOL.API.Repository.Interfaces.Security;
using BOL.API.Service.Interfaces.Security;

namespace BOL.API.Service.Services.Security
{
    public class GrpEntLinkService : IGrpEntLinkService
	{
        private readonly IGrpEntLinkRepository _grpEntLinkRepository;
        private readonly ILogger _logger;

        public GrpEntLinkService(IGrpEntLinkRepository grpEntLinkRepository, ILoggerFactory loggerFactory)
        {
            _grpEntLinkRepository = grpEntLinkRepository;
            _logger = loggerFactory.CreateLogger(nameof(GrpEntLinkService));
        }

        public IEnumerable<GrpEntLink> GetAll()
        {
            return _grpEntLinkRepository.GetAll();
        }

        public GrpEntLink GetById(int id)
        {
            return _grpEntLinkRepository.GetByCondition(x => x.RowId.Equals(id)).Single();
        }

        public void Create(GrpEntLink grpEntLink)
        {
            _grpEntLinkRepository.Create(grpEntLink);
        }

        public void Update(GrpEntLink grpEntLink)
        {
            _grpEntLinkRepository.Update(grpEntLink);
        }

        public void Delete(int id)
        {
            var grpEntLink = GetById(id);
            _grpEntLinkRepository.Delete(grpEntLink);
        }

        public async Task<string> CanAccessAsync(int grpId, int entId)
        {
            return await _grpEntLinkRepository.CanAccessAsync(grpId, entId);
        }

        public async Task<string> GetEntAccessByUserAsync(string userId)
        {
            return await _grpEntLinkRepository.GetEntAccessByUserAsync(userId);
        }

        public async Task<string> GetGrpAccessByEntAsync(int entId)
        {
            return await _grpEntLinkRepository.GetGrpAccessByEntAsync(entId);
        }

        public async Task<string> GetUserAccessByEntAsync(int entId)
        {
            return await _grpEntLinkRepository.GetUserAccessByEntAsync(entId);
        }
    }
}

