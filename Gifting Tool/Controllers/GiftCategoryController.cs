using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftingTool.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiftingTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftCategoryController : ControllerBase
    {

        GiftingRepository<GiftCategory> _repo;
        public GiftCategoryController(GiftingRepository<GiftCategory> repo)
        {
            _repo = repo;
            _repo = new GiftCategoriesRepo(new GiftingToolContext());
        }

        // GET: api/<GiftCategoryController>
        [HttpGet]
        public List<GiftCategory> Get()
        {
            return _repo.GetAll();
        }

        // GET api/<GiftCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GiftCategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GiftCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GiftCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
