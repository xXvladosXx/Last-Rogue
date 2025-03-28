using System;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class ProjectileSetup
    {
        public int ProjectileCount = 1;
        public int ProjectileAmountPerShoot = 1;
        public float Speed;
        public int Pierce = 1;
        public float ContactRadius;
        public float Lifetime;
        
        public float OrbitRadius;
        public float AngleSpeed;
    }
}   