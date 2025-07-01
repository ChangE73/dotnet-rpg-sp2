using dotnet_rpg.Dtos.Monster;

namespace dotnet_rpg.Services.ExternalMonsterService
{
    public interface IExternalMonsterService
    {
        Task<IEnumerable<MonsterDto>> GetStrongMonstersAsync();
    }
}
