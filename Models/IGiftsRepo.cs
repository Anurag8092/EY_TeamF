using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public interface IGiftsRepo
    {
        Task<List<Gifts>> GetAll();
     
    }
}
