using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _abilities;

        public DestroyAbilityEntitiesOnUpgradeSystem(GameContext game)
        {
            _game = game;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.AbilityId,
                    GameMatcher.RecreatedOnUpgrade));
            
            _upgradeRequests = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityId));
        }

        public void Execute()
        {
            foreach (var upgradeRequest in _upgradeRequests)
            {
                foreach (var ability in _abilities)
                {
                    if (upgradeRequest.AbilityId == ability.AbilityId)
                    {
                        foreach (var entity in _game.GetEntitiesWithParentAbility(ability.AbilityId))
                        {
                            entity.isDestructed = true;
                        }

                        ability.isActive = false;
                    }
                }
            }
        }
    }
}