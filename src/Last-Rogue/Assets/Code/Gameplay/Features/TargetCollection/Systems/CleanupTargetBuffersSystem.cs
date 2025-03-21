using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CleanupTargetBuffersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupTargetBuffersSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher.TargetsBuffer);
        }
        
        public void Cleanup()
        {
            foreach (var entity in _entities)
            {
                entity.TargetsBuffer.Clear();
            }
        }
    }
}