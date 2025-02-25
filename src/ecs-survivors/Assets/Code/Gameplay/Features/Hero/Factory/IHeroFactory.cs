using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector2 at);
    }
}