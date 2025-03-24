using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.Features.Enemies.Services.Wave.Configs;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.LevelUp.Configs;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Meta.Features.AfkGain.Configs;
using Code.Meta.UI.Shop.Items;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilityById;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
        private Dictionary<LootTypeId, LootConfig> _lootById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;
        private Dictionary<EnemyTypeId, EnemyConfig> _enemyById;
        
        private List<ShopItemConfig> _shopItemConfigs;
        
        private LevelUpConfig _levelUpConfig;
        private AfkGainConfig _afkGainConfig;
        private WaveConfig _waveConfig;

        public const float ENEMY_SPAWN_TIMER = 1;

        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
            LoadLoot();
            LoadWindows();
            LoadLevelUpConfig();
            LoadAfkGainConfig();
            LoadShopItems();
            LoadEnemies();
            LoadWaveConfig();
        }

        public EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId)
        {
            if (_enemyById.TryGetValue(enemyTypeId, out var config))
                return config;
            
            Debug.LogError($"Enemy with id {enemyTypeId} not found");
            return null;
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

        public LootConfig GetLootConfig(LootTypeId lootTypeId)
        {
            if (_lootById.TryGetValue(lootTypeId, out var config))
            {
                return config;
            }

            Debug.LogError($"Loot with id {lootTypeId} not found");
            return null;
        }

        public GameObject GetWindowPrefab(WindowId id)
        {
            if (_windowPrefabsById.TryGetValue(id, out GameObject prefab))
                return prefab;

            Debug.LogError($"Window prefab with id {id} not found");
            return null;
        }

        public int MaxLevel => _levelUpConfig.MaxLevel;

        public float ExperienceForLevel(int level) =>
            _levelUpConfig.ExperienceForLevel[level];

        public AfkGainConfig AfkGainConfig => _afkGainConfig;

        public ShopItemConfig GetShopItemConfig(ShopItemId shopItemId)
        {
            var config = _shopItemConfigs.FirstOrDefault(x => x.ShopItemId == shopItemId);
            if (config == null)
            {
                Debug.LogError($"Shop item with id {shopItemId} not found");
            }

            return config;
        }

        public List<ShopItemConfig> GetShopItemConfigs => _shopItemConfigs;
        public WaveConfig WaveConfig => _waveConfig;

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

        private void LoadWindows()
        {
            _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/Windows/Window Config")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadLevelUpConfig() => 
            _levelUpConfig = Resources.Load<LevelUpConfig>("Configs/LevelUp/Level Up Config");

        private void LoadAfkGainConfig() => 
            _afkGainConfig = Resources.Load<AfkGainConfig>("Configs/Afk Gain Config");

        private void LoadShopItems() =>
            _shopItemConfigs = Resources
                .LoadAll<ShopItemConfig>("Configs/ShopItems")
                .ToList();

        private void LoadEnemies()
        {
            _enemyById = Resources
                .LoadAll<EnemyConfig>("Configs/Enemies")
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }

        private void LoadWaveConfig() => 
            _waveConfig = Resources.Load<WaveConfig>("Configs/Wave Config");
    }
}