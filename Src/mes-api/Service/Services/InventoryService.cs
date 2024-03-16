using System;
using BOL.API.Repository.Interfaces.EnProd;
using BOL.API.Service.Interfaces;

namespace BOL.API.Service.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IStorageExecRepository _storageExecRepository;
        private readonly ILogger _logger;

		public InventoryService(IStorageExecRepository storageExecRepository, ILoggerFactory loggerFactory)
		{
            _storageExecRepository = storageExecRepository;
            _logger = loggerFactory.CreateLogger(nameof(InventoryService));
		}

        public int AddInv(int entId, string itemId, int gradeCd, int statusCd, double addQty, string? lotNo, double? addQtyErp, DateTime? dateIn, DateTime? expiryDate, string? woId, string? operId, int? seqNo, int? fromEntId, bool? goodsReceived, bool? checkgradestatus)
        {
            throw new NotImplementedException();
        }

        public object GetInventory(int entId, bool? include_moveableEntities, string? lastEditBy, DateTime? lastEditAt)
        {
            throw new NotImplementedException();
        }

        public object GetShortages(int? entId)
        {
            throw new NotImplementedException();
        }

        public int ReduceInv(int entId, string itemId, int gradeCd, int statusCd, double reduceQty, string? lotNo, double? reduceQtyErp, DateTime? dateOut, bool? goodsShipped)
        {
            throw new NotImplementedException();
        }

        public int Split(int oldRowId, double splitQty, int? newEntId, string? newItemId, string? newLotNo, int? newGradeCd, int? newStatusCd, double? addQtyErp)
        {
            throw new NotImplementedException();
        }

        public int Transfer(int fromEntId, int toEntId, string itemId, double transferQty, string? lotNo, double? transferQtyErp)
        {
            throw new NotImplementedException();
        }

        public int TransferAndUpdateInv(int fromEntId, string itemId, double transferQty, int transferOption, int? toEntId, string? toItemId, string? lotNo, string? toLotNo, int? fromGradeCd, int? toGradeCd, int? fromStatusCd, int? toStatusCd, double? transferQtyErp)
        {
            throw new NotImplementedException();
        }
    }
}

