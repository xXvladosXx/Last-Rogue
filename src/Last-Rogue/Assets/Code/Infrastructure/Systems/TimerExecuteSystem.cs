using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Infrastructure.Systems
{
    public abstract class TimerExecuteSystem : IExecuteSystem
    {
        private readonly float _executeInterval;
        private readonly ITimeService _timeService;
        
        private float _timeToExecute;

        protected TimerExecuteSystem(float executeInterval, ITimeService timeService)
        {
            _executeInterval = executeInterval;
            _timeService = timeService;
        }

        protected abstract void Execute();
        
        void IExecuteSystem.Execute()
        {
            _timeToExecute -= _timeService.DeltaTime;
            if (_timeToExecute <= 0)
            {
                Execute();
                _timeToExecute = _executeInterval;
            }
        }
    }
}