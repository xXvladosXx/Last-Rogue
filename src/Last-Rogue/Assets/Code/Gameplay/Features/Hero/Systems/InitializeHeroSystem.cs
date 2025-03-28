using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public InitializeHeroSystem(IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;
        }
        
        public void Initialize()
        {
            _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
            _abilityUpgradeService.UpgradeAbility(AbilityId.VegetableBolt);
            _abilityUpgradeService.UpgradeAbility(AbilityId.VegetableBolt);
            _abilityUpgradeService.UpgradeAbility(AbilityId.VegetableBolt);
            _abilityUpgradeService.UpgradeAbility(AbilityId.VegetableBolt);
            
            _abilityUpgradeService.InitializeAbility(AbilityId.OrbitingMushroom);
            _abilityUpgradeService.UpgradeAbility(AbilityId.OrbitingMushroom);
            _abilityUpgradeService.UpgradeAbility(AbilityId.OrbitingMushroom);
            _abilityUpgradeService.UpgradeAbility(AbilityId.OrbitingMushroom);
            _abilityUpgradeService.UpgradeAbility(AbilityId.OrbitingMushroom);
            
            _abilityUpgradeService.InitializeAbility(AbilityId.GarlicAura);
            _abilityUpgradeService.UpgradeAbility(AbilityId.GarlicAura);
            _abilityUpgradeService.UpgradeAbility(AbilityId.GarlicAura);
            _abilityUpgradeService.UpgradeAbility(AbilityId.GarlicAura);
            
            _abilityUpgradeService.InitializeAbility(AbilityId.ShovelRadialStrike);
            _abilityUpgradeService.UpgradeAbility(AbilityId.ShovelRadialStrike);
            _abilityUpgradeService.UpgradeAbility(AbilityId.ShovelRadialStrike);
            _abilityUpgradeService.UpgradeAbility(AbilityId.ShovelRadialStrike);
            
            _abilityUpgradeService.InitializeAbility(AbilityId.ScatteringFireball);
        }
    }
}