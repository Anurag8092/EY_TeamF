using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public class GiftsRepo : IGiftsRepo
    {
        private GiftTool_ProjDBContext _giftctx;
        //private byte[] key;

        public GiftsRepo()
        {
            _giftctx = new GiftTool_ProjDBContext();
        }

        public GiftsRepo(GiftTool_ProjDBContext giftctx)
        {
            _giftctx = giftctx;
        }
        public async Task<List<Gifts>> GetAll()
        {
            try
            {
                return await _giftctx.Gifts.ToListAsync<Gifts>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
