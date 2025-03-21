using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState : IState, IUpdateable
    {
        private readonly ISystemFactory _systemFactory;
        private readonly GameContext _gameContext;

        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systemFactory,
            GameContext gameContext)
        {
            _systemFactory = systemFactory;
            _gameContext = gameContext;
        }

        public void Enter()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        public void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        public void Exit()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();
            
            DestructEntities();

            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
        }

        private void DestructEntities()
        {
            foreach (var gameEntity in _gameContext.GetEntities())
            {
                gameEntity.isDestructed = true;
            }
        }
    }
}