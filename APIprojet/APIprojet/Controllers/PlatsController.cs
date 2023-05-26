using APIprojet.Models;
using APIprojet.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIprojet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatsController : ControllerBase
{
    private readonly PlatsService _platsService;
    public PlatsController(PlatsService platsService) =>
        _platsService = platsService;

    [HttpGet]
    public async Task<List<Plats>> Get() =>
        await _platsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Plats>> Get(string id)
    {
        var plat = await _platsService.GetAsync(id);

        if (plat is null)
        {
            return NotFound();
        }

        return plat;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Plats newPlat)
    {
        await _platsService.CreateAsync(newPlat);

        return CreatedAtAction(nameof(Get), new { id = newPlat.Id }, newPlat);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Plats updatedPlat)
    {
        var plat = await _platsService.GetAsync(id);

        if (plat is null)
        {
            return NotFound();
        }

        updatedPlat.Id = plat.Id;

        await _platsService.UpdateAsync(id, updatedPlat);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var plat = await _platsService.GetAsync(id);

        if (plat is null)
        {
            return NotFound();
        }

        await _platsService.RemoveAsync(id);

        return NoContent();
    }
}