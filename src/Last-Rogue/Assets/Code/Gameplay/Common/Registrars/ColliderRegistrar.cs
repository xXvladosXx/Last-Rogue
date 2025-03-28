using Code.Common.Extensions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class ColliderRegistrar : EntityComponentRegistrar
    {
        public Collider2D Collider2D;
        public override void RegisterComponents()
        {
            Entity
                .AddCollider(Collider2D);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasCollider)
            {
                Entity.RemoveCollider();
            }
        }
    }
}