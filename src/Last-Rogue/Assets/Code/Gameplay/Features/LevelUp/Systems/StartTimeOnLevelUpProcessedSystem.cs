using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Windows;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class StartTimeOnLevelUpProcessedSystem : ReactiveSystem<GameEntity>
    {
        private readonly ITimeService _timeService;
        private readonly IWindowService _windowService;
        private readonly IGroup<GameEntity> _levelUps;

        public StartTimeOnLevelUpProcessedSystem(GameContext game, ITimeService timeService) : base(game) => 
            _timeService = timeService;

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
            context.CreateCollector(GameMatcher.Processed.Added());

        protected override bool Filter(GameEntity entity) => entity.isLevelUp && entity.isProcessed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity levelUp in entities)
            {
                _timeService.StartTime();
            }
        }
    }
}