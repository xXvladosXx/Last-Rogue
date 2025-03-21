using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public class RemoveEnchantFromHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enchantHolders;
        private readonly IGroup<GameEntity> _enchants;

        public RemoveEnchantFromHolderSystem(GameContext game)
        {
            _enchantHolders = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnchantHolder));
            
            _enchants = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.EnchantTypeId,
                    GameMatcher.Unapplied));
        }

        public void Execute()
        {
            foreach (GameEntity enchantHolder in _enchantHolders)
            {
                foreach (var enchant in _enchants)
                {
                    enchantHolder.EnchantHolder.RemoveEnchant(enchant.EnchantTypeId);
                }
            }
        }
    }
}