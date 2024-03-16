namespace BOL.API.Service.Interfaces;

public interface IInventoryService
{
    int AddInv(int entId, string itemId, int gradeCd, int statusCd, double addQty, string? lotNo, double? addQtyErp, DateTime? dateIn, DateTime? expiryDate, string? woId, string? operId, int? seqNo, int? fromEntId,bool? goodsReceived, bool? checkgradestatus);
    int ReduceInv(int entId, string itemId, int gradeCd, int statusCd, double reduceQty, string? lotNo, double? reduceQtyErp, DateTime? dateOut, bool? goodsShipped);
    int Transfer(int fromEntId, int toEntId, string itemId, double transferQty, string? lotNo, double? transferQtyErp);
    int Split(int oldRowId, double splitQty, int? newEntId, string? newItemId, string? newLotNo, int? newGradeCd, int? newStatusCd, double? addQtyErp);
    int TransferAndUpdateInv(int fromEntId, string itemId, double transferQty, int transferOption, int? toEntId, string? toItemId, string? lotNo, string? toLotNo, int? fromGradeCd, int? toGradeCd, int? fromStatusCd, int? toStatusCd, double? transferQtyErp);
    object GetShortages(int? entId);
    object GetInventory(int entId, bool? include_moveableEntities, string? lastEditBy, DateTime? lastEditAt);
}

