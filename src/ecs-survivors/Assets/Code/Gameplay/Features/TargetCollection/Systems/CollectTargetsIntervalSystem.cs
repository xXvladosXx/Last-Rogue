﻿using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CollectTargetsIntervalSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _entities;

        public CollectTargetsIntervalSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;

            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetsBuffer,
                    GameMatcher.CollectTargetsInterval,
                    GameMatcher.CollectTargetsTimer));
        }
        
        public void Execute()
        {
            foreach (var entity in _entities)
            {
                entity.ReplaceCollectTargetsTimer(entity.CollectTargetsTimer - _timeService.DeltaTime);

                if (entity.CollectTargetsTimer <= 0)
                {
                    entity.isReadyToCollectTargets = true;
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetsInterval);
                }
            }
        }
    }
}