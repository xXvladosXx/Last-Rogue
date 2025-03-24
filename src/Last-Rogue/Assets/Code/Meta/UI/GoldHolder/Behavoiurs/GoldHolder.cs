using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.GoldHolder.Behavoiurs
{
    public class GoldHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private TextMeshProUGUI _boost;
        
        private IStorageUIService _storageUIService;

        [Inject]
        public void Construct(IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }
        
        private void Start()
        {
            _storageUIService.OnGoldChanged += UpdateGold;
            _storageUIService.OnGoldBoostChanged += UpdateBoost;
            
            UpdateGold();
            UpdateBoost();
        }

        private void OnDestroy()
        {
            _storageUIService.OnGoldChanged -= UpdateGold;
            _storageUIService.OnGoldBoostChanged -= UpdateBoost;
        }

        private void UpdateGold() => _goldText.text = _storageUIService.CurrentGold.ToString("0");

        private void UpdateBoost()
        {
            float boost = _storageUIService.GoldGainBoost;

            switch (boost)
            {
                case > 0:
                    _boost.gameObject.SetActive(true);
                    _boost.text = boost.ToString("+0%");
                    break;
                default:
                    _boost.gameObject.SetActive(false);
                    break;
            }
        }
    }
}