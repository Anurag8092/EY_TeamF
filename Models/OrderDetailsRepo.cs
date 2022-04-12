using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public class OrderDetailsRepo : IOrderDetailsRepo
    {
        private GiftTool_ProjDBContext _giftctx;
        public OrderDetailsRepo()
        {
            _giftctx = new GiftTool_ProjDBContext();
        }

        public OrderDetailsRepo(GiftTool_ProjDBContext giftctx)
        {
            _giftctx = giftctx;
        }
        public IEnumerable<OrderDetails> Create(IEnumerable<OrderDetails> detailsList)
        {
            try
            {
                List<OrderDetails> orderDetailsList = new List<OrderDetails>();
                foreach (var o in detailsList)
                {
                    orderDetailsList.Add(o);
                }
                _giftctx.OrderDetails.AddRange(orderDetailsList);
                 _giftctx.SaveChangesAsync();
                return orderDetailsList;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
