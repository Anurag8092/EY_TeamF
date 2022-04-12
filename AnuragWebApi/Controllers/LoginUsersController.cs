using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gift_Auth.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Gift_Auth.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUsersController : ControllerBase
    {
        private readonly GiftTool_ProjDBContext _context;
        private ILoginUserRepo _loginUserRepo;

        public LoginUsersController(ILoginUserRepo repo)
        {
            _loginUserRepo = repo;
            _loginUserRepo = new LoginUserRepo(new GiftTool_ProjDBContext());
        }
        
        // GET: api/LoginUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginUser>>> GetLoginUser()
        {
            return await _loginUserRepo.GetAll();
        }

        // GET: api/LoginUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginUser>> GetLoginUser(int id)
        {
            var loginUserById = await _loginUserRepo.GetById(id);
            if (loginUserById == null) return NotFound();
            return Ok(loginUserById);
        }

        // PUT: api/LoginUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginUser(int id, LoginUser loginUser)
        {
            if (id != loginUser.LoginId)
            {
                return BadRequest();
            }

            _context.Entry(loginUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoginUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoginUser>> PostLoginUser( [FromBody] LoginUser loginUser)
        {
           

           var user = await _loginUserRepo.GetByUserName(loginUser.Email);
            if(user != null)
            {
                if (loginUser.Email == user.Email && loginUser.Password == user.Password)
                {
                    await _loginUserRepo.AuthTrue(user.LoginId);
                    return Ok(user);


                    //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    //var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    //var tokeOptions = new JwtSecurityToken(
                    //    issuer: "http://localhost:59595",
                    //    audience: "http://localhost:59595",
                    //    claims: new List<Claim>(),
                    //    expires: DateTime.Now.AddMinutes(5),
                    //    signingCredentials: signinCredentials
                    //);
                    //var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    //return Ok(new { Token = tokenString, user })
                }
                //return Unauthorized();
                return NotFound("Try to login with correct credentials");
            }
            return BadRequest();
           


         
        }

        // DELETE: api/LoginUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginUser>> DeleteLoginUser(int id)
        {
            var loginUser = await _context.LoginUser.FindAsync(id);
            if (loginUser == null)
            {
                return NotFound();
            }

            _context.LoginUser.Remove(loginUser);
            await _context.SaveChangesAsync();

            return loginUser;
        }

        

        private bool LoginUserExists(int id)
        {
            return _context.LoginUser.Any(e => e.LoginId == id);
        }

    }
}
