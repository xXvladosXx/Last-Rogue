using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Enemies.Services.Wave;
using Code.Gameplay.Features.LevelUp.Services;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;
        private readonly IWaveCounter _waveCounter;
        private readonly ILevelUpService _levelUpService;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public GameOverState(IWindowService windowService,
            IWaveCounter waveCounter,
            ILevelUpService levelUpService,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _windowService = windowService;
            _waveCounter = waveCounter;
            _levelUpService = levelUpService;
            _abilityUpgradeService = abilityUpgradeService;
        }     
        public void Enter()
        {
            _abilityUpgradeService.Cleanup();
            _waveCounter.Cleanup();
            _levelUpService.Reset();
            _windowService.Open(WindowId.GameOverWindow);
        }

        public void Exit()
        {
            
        }
    }
}