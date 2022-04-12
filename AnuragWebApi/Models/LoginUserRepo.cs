using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gift_Auth.Models
{
    
    public class LoginUserRepo : ILoginUserRepo
    {

        private GiftTool_ProjDBContext _giftctx;
        //private byte[] key;

        public LoginUserRepo()
        {
            _giftctx = new GiftTool_ProjDBContext();
        }

        public LoginUserRepo(GiftTool_ProjDBContext giftctx)
        {
            _giftctx = giftctx;
        }

        public async Task<int> Create(LoginUser user)
        {
            try
            {
                _giftctx.LoginUser.Add(user);
                await _giftctx.SaveChangesAsync();
                return user.LoginId;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LoginUser>> GetAll()
        {
            try
            {
                return await _giftctx.LoginUser.ToListAsync<LoginUser>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<LoginUser> GetById(int id)
        {
            try
            {
                return await _giftctx.LoginUser.Where(x => x.LoginId == id).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<LoginUser> GetByUserName(string userName)
        {
            try
            {
                return await _giftctx.LoginUser.Where(x => x.Email == userName).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> AuthTrue(int id)
        {
            try
            {
                var user = await _giftctx.LoginUser.Where(x => x.LoginId == id).FirstOrDefaultAsync();
                if (user == null) return "User Not Found";
                else
                {
                    if (user.IsAuth == true) return "Already Logged In";
                    user.IsAuth = true;
                    await _giftctx.SaveChangesAsync();
                    return "Logged In";
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> AuthFalse(int id)
        {
            try
            {
                var user = await _giftctx.LoginUser.Where(x => x.LoginId == id).FirstOrDefaultAsync();
                if (user == null) return "User Not Found";
                else
                {
                    if (user.IsAuth == true)
                    {
                        user.IsAuth = false;
                        await _giftctx.SaveChangesAsync();
                        return "Logged Out";
                    }
                    else
                    {
                        return "User Not Logged In";
                    }
                  
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
