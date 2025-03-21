using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Windows;
using Entitas;

namespace Code.Gameplay.Features.LevelUp
{
    public class StopTimeOnLevelUpSystem : ReactiveSystem<GameEntity>
    {
        private readonly ITimeService _timeService;
        private readonly IWindowService _windowService;
        private readonly IGroup<GameEntity> _levelUps;

        public StopTimeOnLevelUpSystem(GameContext game, ITimeService timeService) : base(game) => 
            _timeService = timeService;

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
            context.CreateCollector(GameMatcher.LevelUp.Added());

        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity levelUp in entities)
            {
                _timeService.StopTime();
            }
        }
    }
}