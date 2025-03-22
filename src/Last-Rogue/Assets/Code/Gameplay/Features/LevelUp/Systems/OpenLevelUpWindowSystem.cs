using System.Collections.Generic;
using Code.Gameplay.Windows;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class OpenLevelUpWindowSystem : ReactiveSystem<GameEntity>
    {
        private readonly IWindowService _windowService;
        private readonly IGroup<GameEntity> _levelUps;

        public OpenLevelUpWindowSystem(GameContext game, IWindowService windowService) : base(game) => 
            _windowService = windowService;

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
            context.CreateCollector(GameMatcher.LevelUp.Added());

        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity levelUp in entities)
            {
                _windowService.Open(WindowId.LevelUpWindow);
            }
        }
    }
}