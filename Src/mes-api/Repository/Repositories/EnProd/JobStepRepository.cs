﻿//
// JobStepRepository.cs
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
using BOL.API.Domain.Models.EnProd;
using BOL.API.Repository.Helper;
using BOL.API.Repository.Interfaces.EnProd;

namespace BOL.API.Repository.Repositories.EnProd
{
	public class JobStepRepository: RepositoryBase<JobStep>, IJobStepRepository
	{
        private readonly CommandProcessor _CommandProcessor;
        public JobStepRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
             : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<string> StartStepAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> StepLoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> StepLogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> StopStepAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateStepDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateTemplateSpecValuesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

