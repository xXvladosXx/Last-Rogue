using Code.Gameplay.Features.LevelUp.Factory;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
    public class LevelUpWindow : BaseWindow
    {
        public Transform AbilityLayout;
        
        [Inject]
        public void Construct(IAbilityUIFactory abilityUIFactory, IAbili)
        {
            AbilityLayout = abilityLayout;
        }
    }
}