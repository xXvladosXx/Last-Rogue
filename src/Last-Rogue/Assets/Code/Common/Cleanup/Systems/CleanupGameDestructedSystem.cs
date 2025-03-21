using System.Collections.Generic;
using Entitas;

namespace Code.Common.Cleanup.Systems
{
    public class CleanupGameDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public CleanupGameDestructedSystem(GameContext gameContext) => 
            _entities = gameContext.GetGroup(GameMatcher.Destructed);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }
}