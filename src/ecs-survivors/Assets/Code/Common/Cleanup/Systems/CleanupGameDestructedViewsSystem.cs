using Entitas;
using UnityEngine;

namespace Code.Common.Cleanup.Systems
{
    public class CleanupGameDestructedViewsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupGameDestructedViewsSystem(GameContext gameContext) => 
            _entities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destructed,
                GameMatcher.View));

        public void Cleanup()
        {
            foreach (var entity in _entities)
            {
                entity.View.ReleaseEntity();
                Object.Destroy(entity.View.GameObject);
            }
        }
    }
}