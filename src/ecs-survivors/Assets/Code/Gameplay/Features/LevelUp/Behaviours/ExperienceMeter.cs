using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
    public class ExperienceMeter : MonoBehaviour
    {
        public Slider ProgressBar;
        public Image FillImage;
        
        public void SetExperience(float current, float experienceForLevelUp)
        {
            FillImage.type = Image.Type.Tiled;
            ProgressBar.value = current / experienceForLevelUp;
        }
    }
}