using System;
using System.Collections;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
    public class AbilityCard : MonoBehaviour
    {
        public AbilityId AbilityId;
        public Image Icon;
        public TextMeshProUGUI Description;
        public Button Button;
        public GameObject Stamp;
        
        private Action<AbilityId> _onSelected;
        
        private readonly WaitForSeconds _stampAnimationTime = new WaitForSeconds(1);

        public void Setup(AbilityId abilityId, AbilityLevel abilityLevel, Action<AbilityId> onSelected)
        {
            AbilityId = abilityId;
            Icon.sprite = abilityLevel.Icon;
            Description.text = abilityLevel.Description;
            
            _onSelected = onSelected;
            
            Button.onClick.AddListener(SelectCard);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(SelectCard);
        }

        private void SelectCard()
        {
            StartCoroutine(StampAndReport());
        }

        private IEnumerator StampAndReport()
        {
            Stamp.SetActive(true);
            
            yield return _stampAnimationTime;
            
            _onSelected?.Invoke(AbilityId);
        }
    }
}