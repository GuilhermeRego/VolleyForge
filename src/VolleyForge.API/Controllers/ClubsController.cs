using Microsoft.AspNetCore.Mvc;
using VolleyForge.Application.Abstractions.Repositories;
using VolleyForge.Domain.Entities;

namespace VolleyForge.API.Controllers;

[ApiController]
[Route("api/clubs")]
public sealed class ClubsController(IClubRepository clubRepository) : ControllerBase
{
    private readonly IClubRepository _clubRepository = clubRepository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Club> clubs = await _clubRepository.GetAllAsync();

        return Ok(clubs);
    }
}