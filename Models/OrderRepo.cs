using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public class OrderRepo : IOrderRepo
    {

        private GiftTool_ProjDBContext _giftctx;
        //private byte[] key;

        public OrderRepo()
        {
            _giftctx = new GiftTool_ProjDBContext();
        }

        public OrderRepo(GiftTool_ProjDBContext giftctx)
        {
            _giftctx = giftctx;
        }
        public async Task<object> GetById(int id)
        {
            try
            {
                var user = await _giftctx.LoginUser.Where(x => x.LoginId == id).FirstOrDefaultAsync();
                
               if(user.IsAuth == true)
                {
                    var res = from od in _giftctx.OrderDetails
                    join g in _giftctx.Gifts on od.GiftId equals g.GiftId
                    join o in _giftctx.Orders on od.OrderId equals o.OrderId
                    where o.LoginId == id
                    select new
                    {
                        GiftName = g.GiftName,
                        Price = g.Price,
                        Quantity = g.Quantity,
                        Image = g.GiftImg,
                        OrderId = od.OrderId,
                        userId = o.LoginId
                    };
                    if (res != null) return res;
                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<int> OrderGifts(Orders orders)
        {
            try
            {
                _giftctx.Orders.Add(orders);
                await _giftctx.SaveChangesAsync();
                return orders.OrderId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Orders GetId(string type)
        {
            try
            {
                Orders ord;
                if (type == "descending")
                    ord = _giftctx.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault();
                else
                    ord = _giftctx.Orders.OrderBy(x => x.OrderId).FirstOrDefault();
                return ord;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
