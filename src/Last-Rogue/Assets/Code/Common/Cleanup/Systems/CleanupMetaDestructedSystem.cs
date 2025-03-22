using System.Collections.Generic;
using Entitas;

namespace Code.Common.Cleanup.Systems
{
    public class CleanupMetaDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _entities;
        private readonly List<MetaEntity> _buffer = new (16);

        public CleanupMetaDestructedSystem(MetaContext gameContext) => 
            _entities = gameContext.GetGroup(MetaMatcher.Destructed);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }
}