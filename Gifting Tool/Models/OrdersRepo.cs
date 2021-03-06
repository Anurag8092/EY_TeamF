using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftingTool.Models
{
    public class OrdersRepo : GiftingRepository<Orders>
    {
        GiftingToolContext _dbcontext;
        public OrdersRepo()
        {
            _dbcontext = new GiftingToolContext();
        }

        public OrdersRepo(GiftingToolContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public int Create(Orders createData)
        {
            int i = 0;
            try
            {
                if (createData != null)
                {
                    _dbcontext.Orders.Add(createData);
                    _dbcontext.SaveChanges();
                    i = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return i;
        }

        public int Delete(int id)
        {
            int i = 0;
            try
            {
                var order = _dbcontext.Orders.Where(x => x.PkOrderId == id).FirstOrDefault();
                if (order != null)
                {
                    _dbcontext.Orders.Remove(order);
                    _dbcontext.SaveChanges();
                    i = 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public List<Orders> GetAll()
        {
            try
            {
                return _dbcontext.Orders.ToList<Orders>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Orders GetById(string data)
        {
            try
            {
                Orders ord;
                if (data == "descending")
                    ord = _dbcontext.Orders.OrderByDescending(x => x.PkOrderId).FirstOrDefault();
                else
                    ord = _dbcontext.Orders.OrderBy(x => x.PkOrderId).FirstOrDefault();
                return ord;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object orderHistory(int id)
        {
            try
            {
                var user = _dbcontext.Users.Where(x => x.PkUserId == id).FirstOrDefault();

                if (user.IsOnline == true)
                {
                    var res = (from od in _dbcontext.OrderDetails
                              join g in _dbcontext.Gifts on od.FkGiftId equals g.PkGiftId
                              join o in _dbcontext.Orders on od.FkOrderId equals o.PkOrderId
                              where o.FkUserId == id
                              select new
                              {
                                  GiftName = g.GiftName,
                                  Price = g.GiftPrice,
                                  Quantity = g.GiftQuantity,
                                  Image = g.Image,
                                  OrderId = od.FkOrderId,
                                  userId = o.FkUserId
                              }).ToList();
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


        public int Update(int id)
        {
            return 0;
        }
    }
}
