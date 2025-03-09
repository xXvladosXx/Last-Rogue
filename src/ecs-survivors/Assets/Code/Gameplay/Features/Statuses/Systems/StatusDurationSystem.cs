using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class StatusDurationSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _statuses;

        public StatusDurationSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Duration,
                    GameMatcher.Status,
                    GameMatcher.TimerLeft));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.TimerLeft >= 0)
                {
                    status.ReplaceTimerLeft(status.TimerLeft - _timeService.DeltaTime);
                }
                else
                {
                    status.isUnapplied = true;
                }
            }
        }
    }
}
