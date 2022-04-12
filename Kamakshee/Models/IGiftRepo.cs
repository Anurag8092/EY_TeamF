using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifties.Models
{
    public interface IGiftRepo
    {
        Task<List<Gifts>> GetAllGifts();
        IQueryable<object> GetGiftsByCategory(int id);
        Task<Gifts> GetGiftDetails(int id);
        Task<List<GiftCategory>> GetGiftCategories();
    }
}
