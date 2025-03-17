using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IStatusApplier _statusApplier;

        public InitializeHeroSystem(IHeroFactory heroFactory,
            ILevelDataProvider levelDataProvider,
            IAbilityFactory abilityFactory,
            IStatusApplier statusApplier)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _abilityFactory = abilityFactory;
            _statusApplier = statusApplier;
        }
        
        public void Initialize()
        {
            var hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _abilityFactory.CreateVegetableBoltAbility(1);
            _abilityFactory.CreateOrbitalMushroomAbility(1);
            _abilityFactory.CreateGarlicAuraAbility(1);

            _statusApplier.ApplyStatus(new StatusSetup()
            {
                StatusTypeId = StatusTypeId.PoisonEnchant,
                Duration = 20
            }, hero.Id, hero.Id);
            
            _statusApplier.ApplyStatus(new StatusSetup()
            {
                StatusTypeId = StatusTypeId.ExplosiveEnchant,
                Duration = 20
            }, hero.Id, hero.Id);
        }
    }
}