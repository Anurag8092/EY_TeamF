using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public interface IOrderRepo
    {

        Task<Object> GetById(int id);
        Task<int> OrderGifts(Orders orders);
        public Orders GetId(string type);

    }
}
