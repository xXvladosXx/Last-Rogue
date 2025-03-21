using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifierService,
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBoltAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddAbilityId(AbilityId.VegetableBolt)
                .AddCooldown(abilityLevel.Cooldown)
                .With(x => x.isVegetableBoltAbility = true)
                .With(x => x.isRecreatedOnUpgrade = true)
                .PutOnCooldown();
        }
        
        public GameEntity CreateOrbitalMushroomAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddAbilityId(AbilityId.OrbitingMushroom)
                .AddCooldown(abilityLevel.Cooldown)
                .With(x => x.isOrbitingMushroomAbility = true)
                .With(x => x.isRecreatedOnUpgrade = true)
                .PutOnCooldown();
        }
        
        public GameEntity CreateGarlicAuraAbility()
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddAbilityId(AbilityId.GarlicAura)
                .With(x => x.isGarlicAuraAbility = true)
                .With(x => x.isRecreatedOnUpgrade = true);
        }
    }
}