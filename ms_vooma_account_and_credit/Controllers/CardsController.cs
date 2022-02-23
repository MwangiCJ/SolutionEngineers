using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ms_account_and_credit_card.DB;
using ms_account_and_credit_card.Models;

namespace ms_vooma_account_and_credit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly DBCtx _context;

        public CardsController(DBCtx context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public IEnumerable<Card> Getcards()
        {
            return _context.cards;
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await _context.cards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // GET: api/Cards/ForAccount/5
        [HttpGet("ForAccount/{id}")]
        public async Task<IActionResult> GetCardForAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.accounts.Include(e=>e.MyCards).FirstOrDefaultAsync(c=>c.AccountId==id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account.MyCards);
        }

        // PUT: api/Cards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard([FromRoute] int id, [FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.CardId)
            {
                return BadRequest();
            }

            if (card.CardType != _context.cards.Find(id).CardType)
            {
                return BadRequest(new { Message ="Card type cannot be changed."});
            }


            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [HttpPost]
        public async Task<IActionResult> PostCard([FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cardType = card.CardType.Trim().ToUpper();
            string[] allowedCardTypes = new[] {"VIRTUAL", "PHYSICAL"};

            if (!allowedCardTypes.Contains(cardType))
            {
                return BadRequest(new { Message="CardType must be one of the following", AllowedCardTypes = allowedCardTypes });
            }

            _context.cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.CardId }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await _context.cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.cards.Remove(card);
            await _context.SaveChangesAsync();

            return Ok(card);
        }

        private bool CardExists(int id)
        {
            return _context.cards.Any(e => e.CardId == id);
        }
    }
}