using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Registrars
{
    public class DeathRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity
                .With(x => x.isDead = true)
                .With(x => x.isProcessingDeath = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}