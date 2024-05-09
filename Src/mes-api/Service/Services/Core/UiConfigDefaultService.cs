//
// UiConfigDefaultService.cs
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
using BOL.API.Domain.Models.Core;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Service.Interfaces.Core;
using Newtonsoft.Json.Linq;

namespace BOL.API.Service.Services.Core
{
    public class UiConfigDefaultService: IUiConfigDefaultService
	{
        private readonly IUiConfigDefaultRepository _uiConfigDefaultRepository;
        private readonly ILogger _logger;

        public UiConfigDefaultService(IUiConfigDefaultRepository uiConfigDefaultRepository, ILoggerFactory loggerFactory)
        {
            _uiConfigDefaultRepository = uiConfigDefaultRepository;
            _logger = loggerFactory.CreateLogger(nameof(UiConfigDefaultService));
        }

        public IEnumerable<UiConfigDefault> GetAll()
        {
            return _uiConfigDefaultRepository.GetAll();
        }

        public UiConfigDefault GetById(int id)
        {
            return _uiConfigDefaultRepository.GetByCondition(x => x.RowId.Equals(id)).Single();
        }

        public void Create(UiConfigDefault uiConfigDefault)
        {
            _uiConfigDefaultRepository.Create(uiConfigDefault);
        }

        public void Update(UiConfigDefault uiConfigDefault)
        {
            _uiConfigDefaultRepository.Update(uiConfigDefault);
        }

        public void Delete(int id)
        {
            var uiConfigDefault = GetById(id);
            _uiConfigDefaultRepository.Delete(uiConfigDefault);
        }

        public async Task<int> SaveSectionParamsAsync(string jsonData)
        {
            try
            {
                dynamic data = JObject.Parse(jsonData);
                string screen = data.Screen;
                string sectn = data.Sectn;
                List<UiConfigParam> parameters = data.Parameters;

                var response = await Task.Run( () =>
                {
                    var d = _uiConfigDefaultRepository.DeleteAsync(screen, sectn);
                    foreach (UiConfigParam p in parameters)
                    {
                        _uiConfigDefaultRepository.CreateAsync(screen, sectn, p.Parameter);
                    }
                    return 1;
                });

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Invalid data structure", ex);
            }
        }

        internal class UiConfigParam
        {
            public string Parameter { get; set; }
            public string Value { get; set; }

        }
    }
}

