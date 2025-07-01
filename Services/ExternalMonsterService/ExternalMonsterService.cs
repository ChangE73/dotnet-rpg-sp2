using System.Xml.Linq;
using dotnet_rpg.Dtos.Monster;
using Microsoft.Extensions.Logging;

namespace dotnet_rpg.Services.ExternalMonsterService
{
    public class ExternalMonsterService : IExternalMonsterService
    {
        private readonly ILogger<ExternalMonsterService> _logger;
        private readonly IWebHostEnvironment _env;

        public ExternalMonsterService(ILogger<ExternalMonsterService> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public Task<IEnumerable<MonsterDto>> GetStrongMonstersAsync()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "XML", "monsters.xml");
            var doc = XDocument.Load(filePath);
            var monsters = doc.Root?.Elements("monster")
                .Select(m => new MonsterDto
                {
                    Name = m.Element("name")?.Value ?? string.Empty,
                    Hp = int.Parse(m.Element("hp")?.Value ?? "0")
                })
                .Where(m => m.Hp > 100)
                .ToList() ?? new List<MonsterDto>();

            foreach (var monster in monsters)
            {
                _logger.LogInformation("External monster loaded: {Name}", monster.Name);
            }

            return Task.FromResult<IEnumerable<MonsterDto>>(monsters);
        }
    }
}
