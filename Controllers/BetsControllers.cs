using Microsoft.AspNetCore.Mvc;
using MyDbContextApi.Data;
using BetsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BetsApi.Controllers;

[ApiController]
[Route("api/bets")]
public class BetsControllers : ControllerBase
{
    private readonly MyDbContext _context;

    public BetsControllers(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BetsModels>>> GetBetsModels()
    {
        return await _context.Bets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BetsModels>> GetSelectedBet(int id)
    {
        var Bet = await _context.Bets.FindAsync(id);

        if(Bet != null)
        {
            return Bet;
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> PostBetsModels([FromBody] BetsModels betsModels)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Bets.Add(betsModels);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBetsModels) ,new { id = betsModels.Id }, betsModels);
    }
}