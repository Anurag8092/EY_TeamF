using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifties.Models
{
    public class GiftRepo : IGiftRepo

       
    {
        private GiftiesContext _dbcontext;

        public GiftRepo(GiftiesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public GiftRepo()
        {
            _dbcontext = new GiftiesContext();
        }
        public async Task<List<Gifts>> GetAllGifts()
        {
            try
            {
                var allGifts = await _dbcontext.Gifts.ToListAsync<Gifts>();
                return allGifts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Gifts> GetGiftDetails(int id)
        {
            try
            {
                var giftDetails = await _dbcontext.Gifts.Where(x => x.PkGiftId == id).FirstOrDefaultAsync();
                return giftDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  IQueryable<object> GetGiftsByCategory(int id)
        {
            try
            {
                //var giftByCategory = await _dbcontext.Gifts.Where(x => x.FkGiftCategoryId == id).ToListAsync<Gifts>();


                var category =  (from g in _dbcontext.Gifts join c in _dbcontext.GiftCategory on g.FkGiftCategoryId equals c.PkGiftCategoryId
                               where c.PkGiftCategoryId == id
                               select new{
                                   PkGiftId = g.PkGiftId,
                                   GiftName = g.GiftName,
                                   GiftPrice = g.GiftPrice,
                                   GiftQuantity = g.GiftQuantity,
                                   CategoryName = c.CategoryName
                               });

                return category;
              


                 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GiftCategory>> GetGiftCategories()
        {
            try
            {
                var allGiftsCategories = await _dbcontext.GiftCategory.ToListAsync<GiftCategory>();
                return allGiftsCategories;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        
    }
}
