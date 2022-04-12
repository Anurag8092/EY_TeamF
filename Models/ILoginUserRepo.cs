using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    public interface ILoginUserRepo
    {
        Task<int> Create(LoginUser user);
        Task<LoginUser> GetById(int id);
        Task<List<LoginUser>> GetAll();
        Task<LoginUser> GetByUserName(string userName);
        Task<string> AuthTrue(int id);

        Task<string> AuthFalse(int id);
       
    }
}
