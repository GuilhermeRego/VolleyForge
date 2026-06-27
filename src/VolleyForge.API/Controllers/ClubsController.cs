using Microsoft.AspNetCore.Mvc;
using VolleyForge.Domain.Entities;

namespace VolleyForge.API.Controllers;

[ApiController]
[Route("api/clubs")]
public sealed class ClubsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var clubs = new List<Club>
        {
            new ("Associação Desportiva Recreativa Escolar Praiense", "Seniores Masculinos"),
            new ("Associação de Jovens da Fonte do Bastardo", "Seniores Masculinos"),
        };

        return Ok(clubs);
    }
}