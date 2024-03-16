using System;
using BOL.API.Repository.Interfaces.EnProd;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Service.Interfaces;

namespace BOL.API.Service.Services
{
	public class UtilizationService : IUtilizationService
    {
        private readonly IUtilExecRepository _utilExecRepository;
        private readonly ILogger _logger;

        public UtilizationService(IUtilExecRepository utilExecRepository, ILoggerFactory loggerFactory)
        {
            _utilExecRepository = utilExecRepository;
            _logger = loggerFactory.CreateLogger(nameof(UtilizationService));
        }

        public object GetAvailableReasonsAsync()
        {
            throw new NotImplementedException();
        }

        public object GetOldAvailableReasonsAsync()
        {
            throw new NotImplementedException();
        }

        public object GetStatusInfoByUserAsync()
        {
            throw new NotImplementedException();
        }

        public int SetPendingReasonAsync()
        {
            throw new NotImplementedException();
        }

        public int SetRawReasAsync()
        {
            throw new NotImplementedException();
        }

        public int SetReasonAsync()
        {
            throw new NotImplementedException();
        }

        public int UpdateDurationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

