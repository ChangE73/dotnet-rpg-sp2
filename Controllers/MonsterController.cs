using dotnet_rpg.Dtos.Monster;
using dotnet_rpg.Services.ExternalMonsterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : ControllerBase
    {
        private readonly IExternalMonsterService _externalMonsterService;
        public MonsterController(IExternalMonsterService externalMonsterService)
        {
            _externalMonsterService = externalMonsterService;
        }

        [HttpGet("external-monsters")]
        public async Task<ActionResult<IEnumerable<MonsterDto>>> GetExternalMonsters()
        {
            var monsters = await _externalMonsterService.GetStrongMonstersAsync();
            return Ok(monsters);
        }
    }
}
