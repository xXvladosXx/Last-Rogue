using System.Collections.Generic;
using Code.Gameplay.Features.Enemies.Services.Wave.Configs;
using Code.Gameplay.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Services.Wave
{
    public class WaveCounter : IWaveCounter
    {
        private readonly WaveConfig _waveConfig;
        
        private int _currentWaveIndex;
        private Configs.Wave _currentWave;

        public float EnemySpawnInterval => _currentWave.EnemySpawnInterval;

        public WaveCounter(IStaticDataService staticDataService)
        {
            _waveConfig = staticDataService.WaveConfig;

            _currentWaveIndex = 0;
            CreateWave();
        }

        public EnemyTypeId PickUpRandomEnemy()
        {
            if (_currentWave.Enemies.Count == 0)
            {
                _currentWaveIndex++;
                CreateWave();
            }
            
            var enemySpawnConfig = _currentWave.Enemies[Random.Range(0, _currentWave.Enemies.Count)];
            enemySpawnConfig.EnemyCount--;

            if (enemySpawnConfig.EnemyCount == 0)
            {
                _currentWave.Enemies.Remove(enemySpawnConfig);
            }
            
            return enemySpawnConfig.EnemyConfig.EnemyTypeId;
        }

        private void CreateWave()
        {
            if (_currentWaveIndex >= _waveConfig.Waves.Count)
            {
                _currentWaveIndex = 0;
            }
            
            _currentWave = new Configs.Wave
            {
                EnemySpawnInterval = _waveConfig.Waves[_currentWaveIndex].EnemySpawnInterval,
                Enemies = new List<EnemySpawnConfig>()
            };

            foreach (var enemySpawnConfig in _waveConfig.Waves[_currentWaveIndex].Enemies)
            {
                _currentWave.Enemies.Add(new EnemySpawnConfig
                {
                    EnemyCount = enemySpawnConfig.EnemyCount,
                    EnemyConfig = enemySpawnConfig.EnemyConfig,
                });
            }
        }
    }
}