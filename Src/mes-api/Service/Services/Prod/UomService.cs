using BOL.API.Domain.Models.Prod;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Service.Interfaces.Prod;

namespace BOL.API.Service.Services.Prod
{
    public class UomService : IUomService
	{
        private readonly IUomRepository _uomcRepository;
        private readonly ILogger _logger;

        public UomService(IUomRepository uomcRepository, ILoggerFactory loggerFactory)
		{
            _uomcRepository = uomcRepository;
            _logger = loggerFactory.CreateLogger(nameof(UomService));
		}

        public async Task<int> CreateAsync(Uom uom)
        {
            return await _uomcRepository.CreateAsync(uom);
        }

        public async Task<int> DeleteAsync(int uomId)
        {
            var uom = await GetByIdAsync(uomId);
            return await _uomcRepository.DeleteAsync(uom);
        }

        public async Task<Uom> GetByIdAsync(int uomId)
        {
            return await _uomcRepository.GetSingleByConditionAsync(t => t.UomId == uomId);
        }

        public async Task<IEnumerable<Uom>> GetAllAsync()
        {
            return await _uomcRepository.GetAllAsync();
        }

        public async Task<int> UpdateAsync(Uom uom)
        {
            return await _uomcRepository.UpdateAsync(uom);
        }

    }
}

