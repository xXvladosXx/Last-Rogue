using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Common.Cleanup.Systems
{
    public class SelfDestructTimerSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public SelfDestructTimerSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            
            _entities = gameContext.GetGroup(GameMatcher.SelfDestructTime);
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.SelfDestructTime > 0)
                {
                    entity.ReplaceSelfDestructTime(entity.SelfDestructTime - _timeService.DeltaTime);
                }
                else
                {
                    entity.RemoveSelfDestructTime();
                    entity.isDestructed = true;
                }
            }
        }
    }
}