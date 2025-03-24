using System;
using System.Collections.Generic;
using Code.Gameplay.StaticData;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Service
{
    public class ShopUIService : IShopUIService
    {
        private readonly List<ShopItemId> _purchasedItems = new List<ShopItemId>();
        private readonly Dictionary<ShopItemId, ShopItemConfig> _availableItems = new Dictionary<ShopItemId, ShopItemConfig>();
        private readonly IStaticDataService _staticDataService;
        
        public event Action OnShopItemsChanged;

        public ShopUIService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems)
        {
            _purchasedItems.AddRange(purchasedItems);
            RefreshAvailableItems();
        }

        public void UpdatePurchasedItem(ShopItemId requestShopItemId)
        {
            _purchasedItems.Add(requestShopItemId);
            _availableItems.Remove(requestShopItemId);
            
            OnShopItemsChanged?.Invoke();
        }

        public List<ShopItemConfig> GetAvailableItems() => new(_availableItems.Values);
        public ShopItemConfig GetConfig(ShopItemId requestShopItemId) => 
            _availableItems.GetValueOrDefault(requestShopItemId);

        public void Cleanup()
        {
            _purchasedItems.Clear();
            _availableItems.Clear();
            
            OnShopItemsChanged = null;
        }
        
        private void RefreshAvailableItems()
        {
            foreach (var itemConfig in _staticDataService.GetShopItemConfigs)
            {
                if (!_purchasedItems.Contains(itemConfig.ShopItemId))
                {
                    _availableItems.Add(itemConfig.ShopItemId, itemConfig);
                }
            }   
            
            OnShopItemsChanged?.Invoke();
        }
    }
}