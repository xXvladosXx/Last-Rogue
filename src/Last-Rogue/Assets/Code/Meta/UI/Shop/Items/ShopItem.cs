using System;
using Code.Common.Entity;
using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop.Items
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _duration;
        [SerializeField] private TextMeshProUGUI _boost;
        [SerializeField] private Button _buyButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        [SerializeField] private Color _availableColor;
        [SerializeField] private Color _unavailableColor;
        
        private bool _isItemAvailable;
        private int _priceGold;
        private float _currentGold;
        
        private IStorageUIService _storageUIService;
        private ShopItemId _id;

        private bool EnoughGold => _currentGold >= _priceGold;

        [Inject]
        public void Construct(IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }

        public void Setup(ShopItemConfig config)
        {
            _id = config.ShopItemId;
            
            _icon.sprite = config.Icon;
            _price.text = config.Price.ToString();
            _duration.text = TimeSpan.FromSeconds(config.Duration).ToString("m'm 's's'");
            _boost.text = config.Boost.ToString("+0%");
            
            _priceGold = config.Price;
            
            _buyButton.onClick.AddListener(BuyItem);
        }

        private void Start()
        {
            _storageUIService.OnGoldChanged += UpdatePriceThreshold;
            UpdatePriceThreshold();
        }

        private void OnDestroy()
        {
            _storageUIService.OnGoldChanged -= UpdatePriceThreshold;
            
            _buyButton.onClick.RemoveListener(BuyItem);
        }

        public void UpdateAvailability(bool value)
        {
            _isItemAvailable = value;
            
            _canvasGroup.alpha = _isItemAvailable ? 1 : 0.5f;
            
            RefreshBuyButton();
        }

        private void UpdatePriceThreshold()
        {
            _currentGold = _storageUIService.CurrentGold;
            _price.color = EnoughGold ? _availableColor : _unavailableColor;
            
            RefreshBuyButton();
        }

        private void RefreshBuyButton()
        {
            _buyButton.interactable = _isItemAvailable;
        }

        private void BuyItem()
        {
            CreateMetaEntity.Empty()
                .AddShopItemId(_id)
                .isBuyRequest = true;
        }
    }
}