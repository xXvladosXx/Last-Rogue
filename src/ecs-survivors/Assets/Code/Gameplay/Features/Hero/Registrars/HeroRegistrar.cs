using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        public HeroAnimator HeroAnimator;
        public float Speed = 2;
        
        private GameEntity _entiry;

        private void Awake()
        {
            _entiry = CreateEntity
                .Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddSpeed(Speed)
                .AddDirection(Vector2.zero)
                .AddHeroAnimator(HeroAnimator)
                .AddSpriteRenderer(HeroAnimator.SpriteRenderer)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true);
        }
    }
}