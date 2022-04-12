using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gift_Auth.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftsController : ControllerBase
    {
        private readonly GiftTool_ProjDBContext _context;
        private IGiftsRepo _giftsRepo;

        public GiftsController(IGiftsRepo repo)
        {
            _giftsRepo = repo;
            _giftsRepo = new GiftsRepo(new GiftTool_ProjDBContext());
        }

        // GET: api/Gifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gifts>>> GetGifts()
        {
           return await _giftsRepo.GetAll();
        }

        // GET: api/Gifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gifts>> GetGifts(int id)
        {
            var gifts = await _context.Gifts.FindAsync(id);

            if (gifts == null)
            {
                return NotFound();
            }

            return gifts;
        }

        // PUT: api/Gifts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGifts(int id, Gifts gifts)
        {
            if (id != gifts.GiftId)
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

            return CreatedAtAction("GetGifts", new { id = gifts.GiftId }, gifts);
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
            return _context.Gifts.Any(e => e.GiftId == id);
        }
    }
}
