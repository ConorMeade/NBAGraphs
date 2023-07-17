using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAGraphs.Data;
using NBAGraphs.Models;
using StockTracker;

namespace NBAGraphs.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IDataService _dataService;

        public PlayerController(MyDbContext context, IDataService ds)
        {
            _context = context;
            _dataService = ds;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Getplayers()
        {
          if (_context.players == null)
          {
              return NotFound();
          }
            return await _context.players.ToListAsync();
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(string id)
        {
          if (_context.players == null)
          {
              return NotFound();
          }
            var player = await _context.players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Player/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(string id, Player player)
        {
            if (id != player.player_id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        // POST: api/Player
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
          if (_context.players == null)
          {
              return Problem("Entity set 'MyDbContext.players'  is null.");
          }
            _context.players.Add(player);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.player_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayer", new { id = player.player_id }, player);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(string id)
        {
            if (_context.players == null)
            {
                return NotFound();
            }
            var player = await _context.players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Player/rapidapi
        //[HttpPost]
        //public async Task<ActionResult<Player>> GetPlayerGameLog(string rapidId)
        //{

        //}

        private bool PlayerExists(string id)
        {
            return (_context.players?.Any(e => e.player_id == id)).GetValueOrDefault();
        }
    }
}
