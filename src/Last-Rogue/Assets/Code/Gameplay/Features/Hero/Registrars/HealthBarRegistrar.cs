using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HealthBarRegistrar : EntityComponentRegistrar
    {
        public HealthBar HealthBar;
        public override void RegisterComponents() => 
            Entity.AddHealthBar(HealthBar);

        public override void UnregisterComponents()
        {
            if (Entity.hasHealthBar)
                Entity.RemoveHealthBar();
        }
    }
}