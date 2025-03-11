using System;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Behaviours
{
    public class AuraSizeListener : EntityDependant
    {
        public Transform Cotnainer;
        
        private float _radiusPrev;

        private void Update()
        {
            if (Mathf.Approximately(Entity.Radius, _radiusPrev))
            {
                return;
            }
            
            SetAuraScale();
        }

        private void SetAuraScale()
        {
            float scale = Entity.Radius * 2;
            Cotnainer.localScale = new Vector3(scale, scale, scale);

            _radiusPrev = Entity.Radius;
        }
    }
}