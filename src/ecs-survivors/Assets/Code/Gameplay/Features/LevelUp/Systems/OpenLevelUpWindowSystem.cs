using Code.Gameplay.Windows;
using Entitas;

namespace Code.Gameplay.Features.LevelUp
{
    public class OpenLevelUpWindowSystem : IExecuteSystem
    {
        private readonly IWindowService _windowService;
        private readonly IGroup<GameEntity> _levelUps;

        public OpenLevelUpWindowSystem(GameContext game, IWindowService windowService)
        {
            _windowService = windowService;
            _levelUps = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.LevelUp));
        }

        public void Execute()
        {
            foreach (GameEntity levelUp in _levelUps)
            {
                _windowService.Open(WindowId.LevelUpWindow);
            }
        }
    }
}