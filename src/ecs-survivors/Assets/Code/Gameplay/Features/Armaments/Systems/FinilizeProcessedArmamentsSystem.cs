using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class FinilizeProcessedArmamentsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public FinilizeProcessedArmamentsSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Armament,
                    GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.RemoveTargetCollectionComponents();
                entity.isDestructed = true;
            }
        }
    }
}