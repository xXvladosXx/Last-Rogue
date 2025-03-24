using Code.Common.Entity;
using Code.Meta.UI.Shop.Service;
using Entitas;

namespace Code.Meta.UI.Shop.Systems
{
    public class BuyItemOnRequestSystem : IExecuteSystem
    {
        private readonly IShopUIService _shopUIService;
        private readonly IGroup<MetaEntity> _requests;
        private readonly IGroup<MetaEntity> _storages;

        public BuyItemOnRequestSystem(MetaContext meta,
            IShopUIService shopUIService)
        {
            _shopUIService = shopUIService;
            _storages = meta.GetGroup(MetaMatcher
                .AllOf(MetaMatcher.Storage,
                    MetaMatcher.Gold));
            
            _requests = meta.GetGroup(MetaMatcher
                .AllOf(MetaMatcher.BuyRequest,
                    MetaMatcher.ShopItemId));
        }

        public void Execute()
        {
            foreach (var request in _requests)
            {
                foreach (var storage in _storages)
                {
                    var config = _shopUIService.GetConfig(request.ShopItemId);
                    
                    if (storage.Gold >= config.Price)
                    {
                        storage.ReplaceGold(storage.Gold - config.Price);

                        CreateMetaEntity.Empty()
                            .AddShopItemId(request.ShopItemId)
                            .isPurchased = true;
                        
                        _shopUIService.UpdatePurchasedItem(request.ShopItemId);
                    }
                    
                    request.isDestructed = true;
                }
            }
        }
    }
}