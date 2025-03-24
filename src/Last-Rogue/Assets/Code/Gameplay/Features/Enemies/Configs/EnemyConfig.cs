using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Configs
{
    [CreateAssetMenu(menuName = "Last Rogue/Enemy Config", fileName = "Enemy Config", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        public EntityBehaviour ViewPrefab;
        
        public float Health;
        public float Speed;
        public float Damage;
        
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}