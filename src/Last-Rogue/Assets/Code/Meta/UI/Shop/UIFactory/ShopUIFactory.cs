using Code.Infrastructure.AssetManagement;
using Code.Meta.UI.Shop.Items;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Shop.UIFactory
{
    public class ShopUIFactory : IShopUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        private const string SHOP_ITEM_PREFAB_PATH = "UI/Home/Shop/ShopItem";
        
        public ShopUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public ShopItem CreateShopItem(ShopItemConfig config, Transform parent)
        {
            var shopItemPrefab = _assetProvider.LoadAsset<ShopItem>(SHOP_ITEM_PREFAB_PATH);
            var shopItem = _instantiator.InstantiatePrefabForComponent<ShopItem>(shopItemPrefab, parent);

            shopItem.Setup(config);
            
            return shopItem;
        }
    }
}