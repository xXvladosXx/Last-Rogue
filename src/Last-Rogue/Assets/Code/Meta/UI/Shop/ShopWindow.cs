using System;
using System.Collections.Generic;
using Code.Gameplay.Windows;
using Code.Meta.UI.GoldHolder.Service;
using Code.Meta.UI.Shop.Items;
using Code.Meta.UI.Shop.Service;
using Code.Meta.UI.Shop.UIFactory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop
{
    public class ShopWindow : BaseWindow
    {
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private Button _closeButton;
        [SerializeField] private GameObject _noItemsAvailable;
        
        private IWindowService _windowService;
        private IShopUIFactory _shopUIFactory;
        private IShopUIService _shopUIService;
        private IStorageUIService _storageUIService;
        
        private readonly List<ShopItem> _items = new List<ShopItem>();

        [Inject]
        public void Construct(IWindowService windowService,
            IShopUIFactory shopUIFactory,
            IShopUIService shopUIService,
            IStorageUIService storageUIService)
        {
            Id = WindowId.ShopWindow;
            
            _windowService = windowService;
            _shopUIFactory = shopUIFactory;
            _shopUIService = shopUIService;
            _storageUIService = storageUIService;
        }

        protected override void Initialize()
        {
            _closeButton.onClick.AddListener(Close);
        }

        protected override void SubscribeUpdates()
        {
            _shopUIService.OnShopItemsChanged += Refresh;
            _storageUIService.OnGoldBoostChanged += UpdateBoostersState;
            
            Refresh();
        }

        protected override void UnsubscribeUpdates()
        {
            _shopUIService.OnShopItemsChanged -= Refresh;
            _storageUIService.OnGoldBoostChanged -= UpdateBoostersState;

            _closeButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _windowService.Close(Id);
        }

        private void Refresh()
        {
            ClearItems();

            var availableItems = _shopUIService.GetAvailableItems();
            
            _noItemsAvailable.SetActive(availableItems.Count == 0);
            
            FillItems(availableItems);
            
            UpdateBoostersState();
        }

        private void FillItems(List<ShopItemConfig> availableItems)
        {
            foreach (var shopItemConfig in availableItems)
            {
                _items.Add(_shopUIFactory.CreateShopItem(shopItemConfig, _itemsContainer));
            }
        }

        private void UpdateBoostersState()
        {
            var itemsCanBeBought = Math.Abs(_storageUIService.GoldGainBoost) <= float.Epsilon;

            foreach (var item in _items)
            {
                item.UpdateAvailability(itemsCanBeBought);
            }
        }

        private void ClearItems()
        {
            foreach (var item in _items)
            {
                Destroy(item.gameObject);
            }

            _items.Clear();
        }
    }
}