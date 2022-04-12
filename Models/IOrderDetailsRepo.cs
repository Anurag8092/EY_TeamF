using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public interface IOrderDetailsRepo
    {
        public IEnumerable<OrderDetails> Create(IEnumerable<OrderDetails> detailsList);
        
    }
}
