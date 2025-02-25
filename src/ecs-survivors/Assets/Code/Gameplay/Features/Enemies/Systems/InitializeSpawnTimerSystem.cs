using Code.Common.Entity;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class InitializeSpawnTimerSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty().AddSpawnTimer(StaticDataService.ENEMY_SPAWN_TIMER);
        }
    }
}