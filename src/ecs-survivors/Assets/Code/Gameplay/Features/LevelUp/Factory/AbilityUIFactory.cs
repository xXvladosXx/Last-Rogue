using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Factory
{
    public class AbilityUIFactory : IAbilityUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        
        private const string ABILITY_CARD_PREFAB_PATH = "UI/Abilities/AbilityCard";

        public AbilityUIFactory(IInstantiator instantiator, 
            IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public AbilityCard AbilityCard(Transform parent) => 
            _instantiator.InstantiatePrefabForComponent<AbilityCard>(_assetProvider.LoadAsset<AbilityCard>(ABILITY_CARD_PREFAB_PATH), parent);
    }
}