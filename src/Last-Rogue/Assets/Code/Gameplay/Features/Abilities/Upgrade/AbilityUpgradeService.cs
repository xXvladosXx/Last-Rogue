﻿using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Factory;

namespace Code.Gameplay.Features.Abilities.Upgrade
{
    public class AbilityUpgradeService : IAbilityUpgradeService
    {
        private readonly Dictionary<AbilityId, int> _currentAbilities;
        private readonly IRandomService _random;
        private readonly IAbilityFactory _abilityFactory;

        private const int MIN_REPEATED_ABILITIES_TO_OFFER = 1;
        private const int MAX_CARDS_TO_OFFER = 2;

        public AbilityUpgradeService(IRandomService randomService, IAbilityFactory abilityFactory)
        {
            _currentAbilities = new Dictionary<AbilityId, int>();
            _random = randomService;
            _abilityFactory = abilityFactory;
        }

        public int GetAbilityLevel(AbilityId abilityId) =>
            _currentAbilities.GetValueOrDefault(abilityId, 0);

        public void InitializeAbility(AbilityId ability)
        {
            if (!_currentAbilities.TryAdd(ability, 1))
                throw new Exception($"Ability {ability} is already initialized");

            switch (ability)
            {
                case AbilityId.VegetableBolt:
                    _abilityFactory.CreateVegetableBoltAbility(1);
                    break;
                case AbilityId.GarlicAura:
                    _abilityFactory.CreateGarlicAuraAbility();
                    break;
                case AbilityId.OrbitingMushroom:
                    _abilityFactory.CreateOrbitalMushroomAbility(1);
                    break;
                case AbilityId.ShovelRadialStrike:
                    _abilityFactory.CreateShovelRadialStrikeAbility(1);
                    break;
                case AbilityId.ScatteringFireball:
                    _abilityFactory.CreateScatteringFireballAbility(1);
                    break;
                default:
                    throw new Exception($"Ability {ability} is not defined");
            }
        }

        public void UpgradeAbility(AbilityId ability)
        {
            if (_currentAbilities.ContainsKey(ability))
                _currentAbilities[ability]++;
            else
                InitializeAbility(ability);
        }

        public List<AbilityUpgradeOption> GetUpgradeOptions()
        {
            int repeatedAbilitiesToReturnCount = MIN_REPEATED_ABILITIES_TO_OFFER +
                                                 _random.Range(0, Math.Min(_currentAbilities.Count, MAX_CARDS_TO_OFFER));
            int newAbilitiesToReturnCount = Math.Min(MAX_CARDS_TO_OFFER - repeatedAbilitiesToReturnCount,
                UnacquiredAbilities().Count);

            List<AbilityUpgradeOption> upgradeOptions = GetRandomRepeatedAbilities(repeatedAbilitiesToReturnCount);
            upgradeOptions.AddRange(GetRandomUntappedAbilities(newAbilitiesToReturnCount));

            return upgradeOptions;
        }

        private List<AbilityUpgradeOption> GetRandomRepeatedAbilities(int count) =>
            _currentAbilities.Keys
                .OrderBy(_ => _random.Range(0, _currentAbilities.Count))
                .Take(count)
                .Select(abilityId => new AbilityUpgradeOption
                    {Id = abilityId, Level = _currentAbilities[abilityId] + 1})
                .ToList();

        private List<AbilityUpgradeOption> GetRandomUntappedAbilities(int count) =>
            UnacquiredAbilities()
                .OrderBy(_ => _random.Range(0, UnacquiredAbilities().Count))
                .Take(count)
                .Select(abilityId => new AbilityUpgradeOption {Id = abilityId, Level = 1})
                .ToList();

        private List<AbilityId> UnacquiredAbilities() =>
            Enum
                .GetValues(typeof(AbilityId))
                .Cast<AbilityId>()
                .Except(_currentAbilities.Keys)
                .Except(new[] {AbilityId.Unknown})
                .ToList();

        public void Cleanup()
        {
            _currentAbilities.Clear();
        }
    }
}