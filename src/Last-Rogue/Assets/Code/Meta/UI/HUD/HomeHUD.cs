using System;
using Code.Gameplay.Windows;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD
{
    public class HomeHUD : MonoBehaviour
    {
        private IGameStateMachine _stateMachine;
        private IWindowService _windowService;

        public Button StartBattleButton;
        public Button ShopButton;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine,
            IWindowService windowService)
        {
            _stateMachine = gameStateMachine;
            _windowService = windowService;
        }

        private void Start()
        {
            StartBattleButton.onClick.AddListener(EnterBattleLoadingState);
            ShopButton.onClick.AddListener(OpenShop);
        }

        private void OnDestroy()
        {
            StartBattleButton.onClick.RemoveListener(EnterBattleLoadingState);
            ShopButton.onClick.RemoveListener(OpenShop);
        }

        private void OpenShop()
        {
            _windowService.Open(WindowId.ShopWindow);
        }
        
        private void EnterBattleLoadingState() =>
            _stateMachine.Enter<LoadingBattleState, string>(Scenes.MEADOW);
    }
}