using StoreModel;

namespace StoreBL
{
    public interface ILineItemBL
    {
        List<LineItem> GetLineItemByStoreId(int p_id);
    }
}