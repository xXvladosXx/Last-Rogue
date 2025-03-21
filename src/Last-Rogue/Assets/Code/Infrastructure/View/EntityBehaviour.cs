using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private IEntityComponentRegistrar[] _entityComponentRegistrars;
        private ICollisionRegistry _collisionRegistry;
        private Collider2D[] _colliders2D;

        public GameEntity Entity => _entity;

        public GameObject GameObject => gameObject;

        [Inject]
        public void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }
        
        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            _entityComponentRegistrars = GetComponentsInChildren<IEntityComponentRegistrar>();
            
            foreach (var registrar in _entityComponentRegistrars)
            {
                registrar.RegisterComponents();
            }

            _colliders2D = GetComponentsInChildren<Collider2D>(true);
            
            foreach (var collider2D in _colliders2D)
            {
                _collisionRegistry.Register(collider2D.GetInstanceID(), _entity);
            }
        }

        public void ReleaseEntity()
        {
            foreach (var registrar in _entityComponentRegistrars)
            {
                registrar.UnregisterComponents();
            }
            
            foreach (var collider2D in _colliders2D)
            {
                _collisionRegistry.Unregister(collider2D.GetInstanceID());
            }
            
            _entity.Release(this);
            _entity = null;
        }
    }
}