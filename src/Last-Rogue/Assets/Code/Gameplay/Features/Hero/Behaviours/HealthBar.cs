using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Hero.Behaviours
{
    public class HealthBar : MonoBehaviour
    {
        public Image FillImage;
        
        public void SetHealth(float current, float max)
        {
            FillImage.type = Image.Type.Filled;
            FillImage.fillAmount = current / max;
        }
    }
}