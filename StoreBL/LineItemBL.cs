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
        // public LineItem GetLineItem(int p_id)
        // {
        //     LineItem lineItem =  _repo.GetLineItem(p_id);
        //     //listOfLineItem = listOfLineItem.Where(lineitem => lineitem.ProductId.Equals(p_id))
        //     //                        .ToList();
        //      if (lineItem != null)
        //         return lineItem;
        //     else   
        //         throw new Exception("No Line Items found with that ID"); 
        // }
        public List<LineItem> GetLineItemByStoreId(int p_id)
        {
            List<LineItem> listOfLineItem =  _repo.GetLineItemByStoreId(p_id);
            //listOfLineItem = listOfLineItem.Where(lineitem => lineitem.ProductId.Equals(p_id))
            //                        .ToList();
             if (listOfLineItem.Count> 0)
                return listOfLineItem;
            else   
                throw new Exception("No Line Items found with that ID");  
        }
        public LineItem ReplenishQuantity(int p_id, int p_quantity)
        {
            LineItem lineItem = _repo.ReplenishQuantity(p_id, p_quantity);

            return lineItem;
        }
    }
}