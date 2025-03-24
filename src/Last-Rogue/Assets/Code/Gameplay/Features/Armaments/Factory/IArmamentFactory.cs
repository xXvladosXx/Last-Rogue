using Code.Gameplay.Features.Abilities;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentFactory
    {
        GameEntity CreateVegetableBolt(int level, Vector3 at);
        GameEntity CreateOrbitalMushroom(int level, Vector3 at, float phase);
        GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level);
        GameEntity CreateExplosion(int producerId, Vector3 at);
        GameEntity CreateShovelBolt(int level, Vector3 at);
    }
}