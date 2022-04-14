using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftingTool.Models
{
    public class GiftsRepo : GiftingRepository<Gifts>
    {
        private GiftingToolContext _dbcontext;

        public GiftsRepo(GiftingToolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public GiftsRepo()
        {
            _dbcontext = new GiftingToolContext();
        }
        public int Create(Gifts createData)
        {
            return 0;
        }

        public int Delete(int id)
        {
            return 0;
        }

        public List<Gifts> GetAll()
        {
            try
            {
                var allGifts = _dbcontext.Gifts.ToList<Gifts>();
                return allGifts;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Gifts GetById(string data)
        {
            try
            {
                var giftDetails = _dbcontext.Gifts.Where(x => x.PkGiftId == Convert.ToInt32(data)).FirstOrDefault();
                return giftDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Object> GetGiftsByCategory(int id)
        {
            try
            {
                //var giftByCategory = await _dbcontext.Gifts.Where(x => x.FkGiftCategoryId == id).ToListAsync<Gifts>();


                var category = (from g in _dbcontext.Gifts
                                join c in _dbcontext.GiftCategory on g.FkGiftCategoryId equals c.PkGiftCategoryId
                                where c.PkGiftCategoryId == id
                                select new
                                {
                                    PkGiftId = g.PkGiftId,
                                    GiftName = g.GiftName,
                                    GiftPrice = g.GiftPrice,
                                    GiftQuantity = g.GiftQuantity,
                                    CategoryName = c.CategoryName
                                }).ToList<Object>();

                return category;
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
