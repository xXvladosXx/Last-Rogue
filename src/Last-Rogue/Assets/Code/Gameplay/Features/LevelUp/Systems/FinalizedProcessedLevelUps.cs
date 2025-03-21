using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class FinalizedProcessedLevelUpsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _levelUps;

        public FinalizedProcessedLevelUpsSystem(GameContext game)
        {
            _levelUps = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Processed,
                    GameMatcher.LevelUp));
        }

        public void Execute()
        {
            foreach (GameEntity levelUp in _levelUps)
            {
                levelUp.isDestructed = true;
            }
        }
    }
}