//
// PrivService.cs
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
    public class PrivService : IPrivService
	{
        private readonly IPrivRepository _privRepository;
        private readonly ILogger _logger;

        public PrivService(IPrivRepository privRepository, ILoggerFactory loggerFactory)
        {
            _privRepository = privRepository;
            _logger = loggerFactory.CreateLogger(nameof(PrivService));
        }

        public IEnumerable<Priv> GetAll()
        {
            return _privRepository.GetAll();
        }

        public Priv GetById(int id)
        {
            return _privRepository.GetByCondition(x => x.PrivId.Equals(id)).Single();
        }
    }
}

