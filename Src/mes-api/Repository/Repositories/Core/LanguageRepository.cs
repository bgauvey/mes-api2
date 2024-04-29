//
// LanguageRepository.cs
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

using System.Data;
using BOL.API.Domain.Models;
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BOL.API.Repository.Repositories.Core
{
    public class LanguageRepository : RepositoryBase<Language>, ILanguageRepository
	{
        private readonly IConfiguration _Configuration;
        private readonly CommandProcessor _CommandProcessor;

        public LanguageRepository(FactelligenceContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
         : base(context, loggerFactory)
        {
            _Configuration = configuration;
            _CommandProcessor = new CommandProcessor(_Configuration);
        }

        public async Task<int> CloneAsync(int newLangId, int clonedLangId, string newLangDesc)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("new_lang_id", newLangId),
                new KeyValuePair<string, object>("cloned_lang_id", clonedLangId),
                new KeyValuePair<string, object>("new_lang_desc", newLangDesc)
            };
            Command command = new Command()
            {
                Cmd = "Clone",
                MsgType = "",
                Object = "Language",
                Parameters = parameters,
                Schema = "dbo"
            };

            var rowsAffected = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);
            });

            return rowsAffected;
        }

        public async Task<int> DeleteByLangAsync(int langId)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang_id", langId)
            };
            Command command = new Command()
            {
                Cmd = "By_Lang",
                MsgType = "remove",
                Object = "Language",
                Parameters = parameters,
                Schema = "dbo"
            };

            var rowsAffected = await Task.Run(() =>
            {
                return _CommandProcessor.ExecuteCommand(command);
            });

            return rowsAffected;
        }

        public async Task<string> NextFreeLangIdAsync()
        {
            int langId = -1;
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang_id OUTPUT", langId)
            };
            Command command = new Command()
            {
                Cmd = "Next_Free",
                MsgType = "getspec",
                Object = "Language",
                Parameters = parameters,
                Schema = "dbo"
            };

            var rowsAffected = await Task.Run(() =>
            {
                DataTable dt = _CommandProcessor.GetDataTableFromCommand(command);

                var jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);

                return jsonString;
            });

            return rowsAffected;
        }
    }
}

