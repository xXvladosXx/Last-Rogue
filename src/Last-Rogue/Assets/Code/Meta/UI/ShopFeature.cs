using Code.Infrastructure.Systems;
using Code.Meta.UI.Shop.Systems;

namespace Code.Meta.UI
{
    public sealed class ShopFeature : Feature
    {
        public ShopFeature(ISystemFactory systems)
        {
            Add(systems.Create<ProcessBoughtItemsSystem>());
            Add(systems.Create<BuyItemOnRequestSystem>());
        } 
    }
}