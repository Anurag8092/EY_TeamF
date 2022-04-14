using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftingTool.Models
{
    public class GiftCategoriesRepo : GiftingRepository<GiftCategory>
    {
        private GiftingToolContext _dbcontext;

        public GiftCategoriesRepo(GiftingToolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public GiftCategoriesRepo()
        {
            _dbcontext = new GiftingToolContext();
        }
        public int Create(GiftCategory createData)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<GiftCategory> GetAll()
        {
            return _dbcontext.GiftCategory.ToList<GiftCategory>();
        }

        public GiftCategory GetById(string data)
        {
            throw new NotImplementedException();
        }

        public int Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
