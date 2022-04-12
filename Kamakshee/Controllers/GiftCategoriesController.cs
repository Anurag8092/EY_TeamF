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
    public class GiftCategoriesController : ControllerBase
    {
        private readonly GiftiesContext _context;
        private IGiftRepo _repo;

        public GiftCategoriesController(IGiftRepo repo)
        {
            _repo = repo;
            _repo = new GiftRepo(new GiftiesContext());
        }

        // GET: api/GiftCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftCategory>>> GetGiftCategory()
        {
            return await _repo.GetGiftCategories();
        }

        // GET: api/GiftCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiftCategory>> GetGiftCategory(int id)
        {
            var giftCategory = await _context.GiftCategory.FindAsync(id);

            if (giftCategory == null)
            {
                return NotFound();
            }

            return giftCategory;
        }

        // PUT: api/GiftCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiftCategory(int id, GiftCategory giftCategory)
        {
            if (id != giftCategory.PkGiftCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(giftCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftCategoryExists(id))
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

        // POST: api/GiftCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GiftCategory>> PostGiftCategory(GiftCategory giftCategory)
        {
            _context.GiftCategory.Add(giftCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiftCategory", new { id = giftCategory.PkGiftCategoryId }, giftCategory);
        }

        // DELETE: api/GiftCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GiftCategory>> DeleteGiftCategory(int id)
        {
            var giftCategory = await _context.GiftCategory.FindAsync(id);
            if (giftCategory == null)
            {
                return NotFound();
            }

            _context.GiftCategory.Remove(giftCategory);
            await _context.SaveChangesAsync();

            return giftCategory;
        }

        private bool GiftCategoryExists(int id)
        {
            return _context.GiftCategory.Any(e => e.PkGiftCategoryId == id);
        }
    }
}
