using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Cooldowns.Systems
{
    public class CooldownSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _cooldownsables;
        private readonly List<GameEntity> _buffer = new (100);

        public CooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _cooldownsables = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft));
        }

        public void Execute()
        {
            foreach (GameEntity cooldownable in _cooldownsables.GetEntities(_buffer))
            {
                cooldownable.ReplaceCooldownLeft(cooldownable.CooldownLeft - _timeService.DeltaTime);

                if (cooldownable.CooldownLeft <= 0)
                {
                    cooldownable.isCooldownUp = true;
                    cooldownable.RemoveCooldownLeft();
                }
            }
        }
    }
}