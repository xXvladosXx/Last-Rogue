using System.Collections.Generic;
using Code.Infrastructure.Progress.SaveLoad;
using Code.Meta.UI.Shop.Factory;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public class ProcessBoughtItemsSystem : ReactiveSystem<MetaEntity>
    {
        private readonly IShopItemFactory _shopItemFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGroup<MetaEntity> _boosters;

        public ProcessBoughtItemsSystem(MetaContext context,
            IShopItemFactory shopItemFactory,
            ISaveLoadService saveLoadService) : base(context)
        {
            _shopItemFactory = shopItemFactory;
            _saveLoadService = saveLoadService;
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context) => 
            context.CreateCollector(MetaMatcher.Purchased.Added());

        protected override bool Filter(MetaEntity entity) => entity.hasShopItemId;

        protected override void Execute(List<MetaEntity> purchases)
        {
            foreach (var purchase in purchases)
            {
                _shopItemFactory.CreateShopItem(purchase.ShopItemId);
            }        
            
            _saveLoadService.SaveProgress();
        }
    }
}