using Code.Gameplay.Meta;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly ISystemFactory _systemFactory;
        private readonly GameContext _gameContext;

        private HomeScreenFeature _homeScreenFeature;

        public HomeScreenState(ISystemFactory systemFactory, 
            GameContext gameContext)
        {
            _systemFactory = systemFactory;
            _gameContext = gameContext;
        }
        
        public void Enter()
        {
            _homeScreenFeature = _systemFactory.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        public void Update()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        public void Exit()
        {
            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();
            
            DestructEntities();

            _homeScreenFeature.Cleanup();
            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
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