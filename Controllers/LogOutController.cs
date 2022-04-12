using Gift_Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gift_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogOutController : ControllerBase
    {
        private ILoginUserRepo _loginUserRepo;

        public LogOutController(ILoginUserRepo repo)
        {
            _loginUserRepo = repo;
            _loginUserRepo = new LoginUserRepo(new GiftTool_ProjDBContext());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<LoginUser>> LogOutUser(int id)
        {
            await _loginUserRepo.AuthFalse(id);
            return Ok("You are Logged Out");
        }
    }
}
