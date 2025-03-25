using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public GameOverState(IWindowService windowService,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _windowService = windowService;
            _abilityUpgradeService = abilityUpgradeService;
        }     
        public void Enter()
        {
            _abilityUpgradeService.Cleanup();
            _windowService.Open(WindowId.GameOverWindow);
        }

        public void Exit()
        {
            
        }
    }
}