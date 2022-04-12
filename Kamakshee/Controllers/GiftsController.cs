using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gifties.Models;

namespace Gifties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly GiftiesContext _context;
        private IGiftRepo _repo;

        public GiftsController(IGiftRepo repo)
        {
            _repo = repo;
            _repo = new GiftRepo(new GiftiesContext());
        }

       

        // GET: api/Gifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gifts>>> GetGifts()
        {
            return await _repo.GetAllGifts();
        }

        // GET: api/Gifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gifts>> GetGifts(int id)
        {
            return await _repo.GetGiftDetails(id);
        }

        [HttpGet("category/{id}")]
        public  IQueryable<object> GetGiftsByCategory(int id)
        {
            return _repo.GetGiftsByCategory(id);
        }



        // PUT: api/Gifts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGifts(int id, Gifts gifts)
        {
            if (id != gifts.PkGiftId)
            {
                return BadRequest();
            }

            _context.Entry(gifts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftsExists(id))
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

        // POST: api/Gifts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gifts>> PostGifts(Gifts gifts)
        {
            _context.Gifts.Add(gifts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGifts", new { id = gifts.PkGiftId }, gifts);
        }

        // DELETE: api/Gifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gifts>> DeleteGifts(int id)
        {
            var gifts = await _context.Gifts.FindAsync(id);
            if (gifts == null)
            {
                return NotFound();
            }

            _context.Gifts.Remove(gifts);
            await _context.SaveChangesAsync();

            return gifts;
        }

        private bool GiftsExists(int id)
        {
            return _context.Gifts.Any(e => e.PkGiftId == id);
        }
    }
}
