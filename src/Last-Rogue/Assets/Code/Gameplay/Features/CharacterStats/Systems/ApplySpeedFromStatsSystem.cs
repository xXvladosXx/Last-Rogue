﻿using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.CharacterStats.Systems
{
    public class ApplySpeedFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplySpeedFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.StatModifiers, 
                    GameMatcher.BaseStats,
                    GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceSpeed(MoveSpeed(statOwner).ZeroIfNegative());
            }
        }

        private float MoveSpeed(GameEntity statOwner) => 
            statOwner.BaseStats[Stats.Speed] + statOwner.StatModifiers[Stats.Speed];
    }
}