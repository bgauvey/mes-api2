//
// UiConfigRepository.cs
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

using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Utils;
using Microsoft.Extensions.Logging;

namespace BOL.API.Repository.Repositories.Core
{
    public class UiConfigRepository : RepositoryBase<UiConfig>, IUiConfigRepository
	{
        private readonly CommandProcessor _CommandProcessor;

        public UiConfigRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _CommandProcessor = new CommandProcessor(configuration);
        }

        public async Task<int> DeleteAsync(string configId, string screenId, string sectionId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("config_id", configId),
                new KeyValuePair<string, object>("screen", screenId),
                new KeyValuePair<string, object>("sectn", sectionId)
            };
            Command command = new Command()
            {
                Cmd = "",
                MsgType = "remove",
                Object = "ui_config",
                Parameters = parameters,
                Schema = "dbo"
            };

            var rowsAffected = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);
            });

            return rowsAffected;
        }
    }
}

