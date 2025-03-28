using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class Enchant : MonoBehaviour
    {
        public Image Icon;
        public EnchantTypeId Id;
        public TextMeshProUGUI Name;

        public void Set(EnchantConfig config)
        {
            Id = config.TypeId;
            Icon.sprite = config.Icon;
            Name.text = config.Name;
        }
    }
}