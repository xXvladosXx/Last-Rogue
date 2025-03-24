using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Enemies.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Services.Wave.Configs
{
    [Serializable]
    public class EnemySpawnConfig
    {
        public int EnemyCount;
        public EnemyConfig EnemyConfig;
    }

    [Serializable]
    public class Wave
    {
        public float EnemySpawnInterval;
        public List<EnemySpawnConfig> Enemies;
    }
    
    [CreateAssetMenu(menuName = "Last Rogue/Wave Config", fileName = "Wave Config", order = 0)]
    public class WaveConfig : ScriptableObject
    {
        public List<Wave> Waves;
    }
}