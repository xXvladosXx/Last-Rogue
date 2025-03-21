using UnityEngine;

namespace Code.Gameplay.Features.Loot.Factory
{
    public interface ILootFactory
    {
        GameEntity CreateLoot(LootTypeId lootTypeId, Vector2 at);
    }
}