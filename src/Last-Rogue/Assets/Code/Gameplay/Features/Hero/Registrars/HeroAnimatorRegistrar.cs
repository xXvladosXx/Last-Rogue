using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroAnimatorRegistrar : EntityComponentRegistrar
    {
        public HeroAnimator HeroAnimator;

        public override void RegisterComponents()
        {
            Entity
                .AddHeroAnimator(HeroAnimator)
                .AddAnimatorDamageTaken(HeroAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasHeroAnimator)
            {
                Entity.RemoveHeroAnimator();
            }

            if (Entity.hasAnimatorDamageTaken)
            {
                Entity.RemoveAnimatorDamageTaken();
            }
        }
    }
}