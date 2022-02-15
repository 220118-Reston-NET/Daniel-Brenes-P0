using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class LineItemBL : ILineItemBL
    {
        private IRepo _repo;
        public LineItemBL(IRepo p_repo)
        {
            _repo = p_repo;
        }
        public List<LineItem> GetLineItemByStoreId(int p_id)
        {
            List<LineItem> listOfLineItem = new List<LineItem>();

            return listOfLineItem;
        }
    }
}