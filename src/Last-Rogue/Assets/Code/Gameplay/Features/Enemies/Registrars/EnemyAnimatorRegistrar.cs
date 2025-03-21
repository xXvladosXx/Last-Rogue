using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;

        public override void RegisterComponents()
        {
            Entity
                .AddEnemyAnimator(EnemyAnimator)
                .AddAnimatorDamageTaken(EnemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnemyAnimator)
            {
                Entity.RemoveEnemyAnimator();
            }

            if (Entity.hasAnimatorDamageTaken)
            {
                Entity.RemoveAnimatorDamageTaken();
            }
        }
    }
}