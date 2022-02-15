using StoreModel;

namespace StoreBL
{
    public interface ILineItemBL
    {
        List<LineItem> GetLineItemByStoreId(int p_id);
        LineItem ReplenishQuantity(int p_id, int p_quantity);
        //LineItem GetLineItem(int p_id);
    }
}