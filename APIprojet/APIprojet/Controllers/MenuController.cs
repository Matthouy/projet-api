using APIprojet.Models;
using APIprojet.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIprojet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly MenuService _menuService;
    public MenuController(MenuService menuService) =>
        _menuService = menuService;

    [HttpGet]
    public async Task<List<Menu>> Get() =>
        await _menuService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Menu>> Get(string id)
    {
        var menu = await _menuService.GetAsync(id);

        if (menu is null)
        {
            return NotFound();
        }

        return menu;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Menu newMenu)
    {
        await _menuService.CreateAsync(newMenu);

        return CreatedAtAction(nameof(Get), new { id = newMenu.Id }, newMenu);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Menu updatedMenu)
    {
        var menu = await _menuService.GetAsync(id);

        if (menu is null)
        {
            return NotFound();
        }

        updatedMenu.Id = menu.Id;

        await _menuService.UpdateAsync(id, updatedMenu);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var menu = await _menuService.GetAsync(id);

        if (menu is null)
        {
            return NotFound();
        }

        await _menuService.RemoveAsync(id);

        return NoContent();
    }
}
