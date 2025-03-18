using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId, AbilityConfig> _abilityById;
    private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
    private Dictionary<LootTypeId, LootConfig> _lootById;
    
    public const float ENEMY_SPAWN_TIMER = 1;

    public void LoadAll()
    {
      LoadAbilities();
      LoadEnchants();
      LoadLoot();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityById.TryGetValue(abilityId, out var config)) 
        return config;
      
      Debug.LogError($"Ability with id {abilityId} not found");
      return null;
    }

    public EnchantConfig GetEnchantConfig(EnchantTypeId enchantTypeId)
    {
      if (_enchantById.TryGetValue(enchantTypeId, out var config)) 
        return config;
      
      Debug.LogError($"Enchant with id {enchantTypeId} not found");
      return null;
    }

    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      var config = GetAbilityConfig(abilityId);
      return config == null ? null : config.Levels[level - 1];
    }

    private void LoadEnchants()
    {
      _enchantById = Resources
        .LoadAll<EnchantConfig>("Configs/Enchants")
        .ToDictionary(x => x.TypeId, x => x);
    }

    private void LoadLoot()
    {
      _lootById = Resources
        .LoadAll<LootConfig>("Configs/Loot")
        .ToDictionary(x => x.LootTypeId, x => x);
    }

    private void LoadAbilities()
    {
      _abilityById = Resources
        .LoadAll<AbilityConfig>("Configs/Abilities")
        .ToDictionary(x => x.AbilityId, x => x);
    }

    public LootConfig GetLootConfig(LootTypeId lootTypeId)
    {
      if (_lootById.TryGetValue(lootTypeId, out var config))
      {
        return config;
      }
      
      Debug.LogError($"Loot with id {lootTypeId} not found");
      return null;
    }
  }
}