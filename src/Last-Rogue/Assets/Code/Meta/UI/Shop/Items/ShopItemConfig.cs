using UnityEngine;

namespace Code.Meta.UI.Shop.Items
{
    [CreateAssetMenu(menuName = "Last Rogue/ShopItem Config", fileName = "shopItemConfig")]
    public class ShopItemConfig : ScriptableObject
    {
        public ShopItemId ShopItemId;
        public ShopItemKind Kind;

        public Sprite Icon;
        public int Price;

        public float Duration;
        public float Boost;
    }
}