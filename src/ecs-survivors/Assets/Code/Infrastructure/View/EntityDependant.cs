using System;
using UnityEngine;

namespace Code.Infrastructure.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityView;

        public GameEntity Entity
        {
            get
            {
                if (EntityView == null)
                {
                    EntityView = GetComponent<EntityBehaviour>();
                }

                if (EntityView == null)
                {
                    Debug.LogError("Entity View is null");
                }

                return EntityView != null ? EntityView.Entity : null;
            }
        }
    }
}