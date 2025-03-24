using Code.Gameplay.Common.Time;
using Code.Infrastructure.Progress.SaveLoad;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.Progress.Systems
{
    public class PeriodicallySaveProgressSystem : TimerExecuteSystem
    {
        private readonly ISaveLoadService _saveLoadService;

        public PeriodicallySaveProgressSystem(float executeInterval, 
            ITimeService timeService, 
            ISaveLoadService saveLoadService) : base(executeInterval, timeService)
        {
            _saveLoadService = saveLoadService;
        }

        protected override void Execute()
        {
            _saveLoadService.SaveProgress();
        }
    }
}