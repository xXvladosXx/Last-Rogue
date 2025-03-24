using Code.Infrastructure.Progress;
using Code.Meta.UI.Shop.Items;
using Entitas;

namespace Code.Meta.UI.Shop
{
    [Meta] public class ShopItemIdComponent : ISavedComponent { public ShopItemId Value; }
    [Meta] public class Purchased : ISavedComponent { }
    [Meta] public class BuyRequestComponent : IComponent { }
}