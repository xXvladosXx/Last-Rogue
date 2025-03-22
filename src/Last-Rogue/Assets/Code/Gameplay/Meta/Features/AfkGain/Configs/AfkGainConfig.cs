using UnityEngine;

namespace Code.Gameplay.Meta.Features.AfkGain.Configs
{
    [CreateAssetMenu(menuName = "Last Rogue/Afk Gain Config", fileName = "Afk Gain Config", order = 0)]
    public class AfkGainConfig : ScriptableObject
    {
        public float GainGoldPerSecond = 1f;
        public const float SIMULATION_TICK = 1;
    }
}