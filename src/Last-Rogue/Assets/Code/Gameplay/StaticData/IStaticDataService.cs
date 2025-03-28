﻿using System.Collections.Generic;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.Features.Enemies.Services.Wave.Configs;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Meta.Features.AfkGain.Configs;
using Code.Meta.UI.Shop.Items;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        AbilityConfig GetAbilityConfig(AbilityId abilityId);
        AbilityLevel GetAbilityLevel(AbilityId abilityId, int level);
        EnchantConfig GetEnchantConfig(EnchantTypeId enchantTypeId);
        LootConfig GetLootConfig(LootTypeId lootTypeId);
        GameObject GetWindowPrefab(WindowId id);
        int MaxLevel { get; }
        AfkGainConfig AfkGainConfig { get; }
        List<ShopItemConfig> GetShopItemConfigs { get; }
        WaveConfig WaveConfig { get; }
        float ExperienceForLevel(int level);
        ShopItemConfig GetShopItemConfig(ShopItemId shopItemId);
        EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId);
    }
}