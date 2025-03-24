using Code.Infrastructure.Systems;
using Code.Meta.UI;
using Code.Meta.UI.GoldHolder.Systems;
using Code.Meta.UI.Shop.Systems;

namespace Code.Meta
{
    public class HomeUIFeature : Feature
    {
        public HomeUIFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializePurchasedItemSystem>());
            Add(systemFactory.Create<RefreshGoldGainBoostSystem>());
            Add(systemFactory.Create<RefreshGoldSystem>());
            Add(systemFactory.Create<ShopFeature>());
        }
    }
}