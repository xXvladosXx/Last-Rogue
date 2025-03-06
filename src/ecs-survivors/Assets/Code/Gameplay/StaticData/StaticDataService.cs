using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId,AbilityConfig> _abilityById;
    public const float ENEMY_SPAWN_TIMER = 1;

    public void LoadAll()
    {
      LoadAbilities();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityById.TryGetValue(abilityId, out var config)) 
        return config;
      
      Debug.LogError($"Ability with id {abilityId} not found");
      return null;
    }
    
    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      var config = GetAbilityConfig(abilityId);
      return config == null ? null : config.Levels[level - 1];
    }

    private void LoadAbilities()
    {
      _abilityById = Resources
        .LoadAll<AbilityConfig>("Configs/Abilities/VegetableBoltConfig")
        .ToDictionary(x => x.AbilityId, x => x);
    }
  }
}