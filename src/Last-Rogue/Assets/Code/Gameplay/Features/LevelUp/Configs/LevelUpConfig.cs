using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp.Configs
{
    [CreateAssetMenu(menuName = "Last Rogue/Level Up Config", fileName = "Level Up Config", order = 0)]
    public class LevelUpConfig : ScriptableObject
    {
        public int MaxLevel;
        public List<float> ExperienceForLevel;
    }
}