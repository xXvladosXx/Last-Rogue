using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;
using Code.Meta.UI.GoldHolder.Service;
using Code.Meta.UI.Shop.Service;

namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly ISystemFactory _systemFactory;
        private readonly GameContext _gameContext;
        private readonly IStorageUIService _storageUIService;
        private readonly IShopUIService _shopUIService;

        private HomeScreenFeature _homeScreenFeature;

        public HomeScreenState(ISystemFactory systemFactory, 
            GameContext gameContext, 
            IStorageUIService storageUIService,
            IShopUIService shopUIService)
        {
            _systemFactory = systemFactory;
            _gameContext = gameContext;
            _storageUIService = storageUIService;
            _shopUIService = shopUIService;
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
            _storageUIService.Cleanup();
            _shopUIService.Cleanup();
            
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