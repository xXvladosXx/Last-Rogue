using System;
using System.Collections.Generic;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Service
{
    public interface IShopUIService
    {
        event Action OnShopItemsChanged;
        void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems);
        void UpdatePurchasedItem(ShopItemId requestShopItemId);
        List<ShopItemConfig> GetAvailableItems();
        ShopItemConfig GetConfig(ShopItemId requestShopItemId);
        void Cleanup();
    }
}