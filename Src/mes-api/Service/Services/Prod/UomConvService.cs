using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces.Prod;

namespace BOL.API.Service.Services.Prod
{
    public class UomConvService : IUomConvService
	{
        private readonly IUomConvRepository _uomConvcRepository;
        private readonly ILogger _logger;

        public UomConvService(IUomConvRepository uomConvcRepository, ILoggerFactory loggerFactory)
		{
            _uomConvcRepository = uomConvcRepository;
            _logger = loggerFactory.CreateLogger(nameof(UomConvService));
		}

        public async Task<int> CreateAsync(UomConv uomConv)
        {
            return await _uomConvcRepository.CreateAsync(uomConv);
        }

        public async Task<int> DeleteAsync(int rowId)
        {
            var uomConv = await GetByIdAsync(rowId);
            return await _uomConvcRepository.DeleteAsync(uomConv);
        }

        public async Task<UomConv> GetByIdAsync(int rowId)
        {
            return await _uomConvcRepository.GetSingleByConditionAsync(t => t.RowId == rowId);
        }

        public async Task<IEnumerable<UomConv>> GetAllAsync()
        {
            return await _uomConvcRepository.GetAllAsync();
        }

        public async Task<int> UpdateAsync(UomConv uomConv)
        {
            return await _uomConvcRepository.UpdateAsync(uomConv);
        }

    }
}

