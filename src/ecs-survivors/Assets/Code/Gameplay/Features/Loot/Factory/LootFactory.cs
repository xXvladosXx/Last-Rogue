using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Factory
{
    public class LootFactory : ILootFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public LootFactory(IIdentifierService identifierService,
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateLoot(LootTypeId lootTypeId, Vector2 at)
        {
            var lootConfig = _staticDataService.GetLootConfig(lootTypeId);
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddLootTypeId(lootTypeId)
                .AddViewPrefab(lootConfig.ViewPrefab)
                .With(x => x.AddEffectSetups(lootConfig.EffectsSetups), !lootConfig.EffectsSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(lootConfig.StatusSetups), !lootConfig.StatusSetups.IsNullOrEmpty())
                .With(x => x.AddExperience(lootConfig.Experience), lootConfig.Experience > 0)
                .With(x => x.isPullable = true);
        }
    }
}