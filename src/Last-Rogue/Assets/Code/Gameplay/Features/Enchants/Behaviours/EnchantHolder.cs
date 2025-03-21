using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder : MonoBehaviour
    {
        public Transform Enchantlayout;
        private IEnchantUIFactory _enchantUIFactory;
        private readonly List<Enchant> _enchants = new();

        [Inject]
        public void Construct(IEnchantUIFactory enchantUIFactory) => 
            _enchantUIFactory = enchantUIFactory;

        public void AddEnchant(EnchantTypeId typeId)
        {
            if (FindAlreadyHeld(typeId)) 
                return;
            
            var enchant = _enchantUIFactory.CreateEnchant(Enchantlayout, typeId);
            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId typeId)
        {
            var enchant = _enchants.Find(x => x.Id == typeId);
            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }

        private bool FindAlreadyHeld(EnchantTypeId typeId) => 
            _enchants.Find(x => x.Id == typeId) != null;
    }
}