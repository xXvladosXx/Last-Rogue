using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Enemies.Services.Wave;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IWaveCounter _waveCounter;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public GameOverState(IWindowService windowService,
            IWaveCounter waveCounter,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _windowService = windowService;
            _waveCounter = waveCounter;
            _abilityUpgradeService = abilityUpgradeService;
        }     
        public void Enter()
        {
            _abilityUpgradeService.Cleanup();
            _waveCounter.Cleanup();
            _windowService.Open(WindowId.GameOverWindow);
        }

        public void Exit()
        {
            
        }
    }
}