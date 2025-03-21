using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class MarkProcessedOnTargetLimitExceededSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkProcessedOnTargetLimitExceededSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Armament,
                    GameMatcher.TargetLimit,
                    GameMatcher.ProcessedTargets));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity.ProcessedTargets.Count >= entity.TargetLimit)
                {
                    entity.isProcessed = true;
                }
            }
        }
    }
}