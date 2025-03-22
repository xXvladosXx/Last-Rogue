using System;
using System.Linq;
using Code.Common.Extensions;
using Entitas;

namespace Code.Infrastructure.Progress
{
    public static class ProgressEntityExtensions
    {
        public static IEntity HydrateWith (this IEntity entity, EntitySnapshot snapshot)
        {
            foreach (var component in snapshot.Components)
            {
                var lookupIndex = Array.IndexOf(MetaComponentsLookup.componentTypes, component.GetType());
                entity.With(x => x.ReplaceComponent(lookupIndex, component), lookupIndex >= 0);
            }

            return entity;
        }
        
        public static EntitySnapshot AsSavedEntity(this IEntity entity)
        {
            var components = entity.GetComponents();

            return new EntitySnapshot
            {
                Components = components
                    .Where(c => c is ISavedComponent)
                    .Cast<ISavedComponent>()
                    .ToList()
            };
        }
    }
}