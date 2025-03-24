﻿using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDropLootSystem : IExecuteSystem
    {
        private readonly ILootFactory _lootFactory;
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDropLootSystem(GameContext game, ILootFactory lootFactory)
        {
            _lootFactory = lootFactory;
            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy,
                    GameMatcher.WorldPosition,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
               
                {
                    _lootFactory.CreateLoot(LootTypeId.Experience, enemy.WorldPosition);
                }
            }
        }
    }
}