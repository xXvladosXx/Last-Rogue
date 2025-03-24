using System.Collections.Generic;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
    public class CleanupTickSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _group;
        private readonly List<MetaEntity> _buffer = new(1);

        public CleanupTickSystem(MetaContext meta)
        {
            _group = meta.GetGroup(MetaMatcher.Tick);
        }

        public void Cleanup()
        {
            foreach (MetaEntity tick in _group.GetEntities(_buffer))
            {
                tick.Destroy();
            }
        }
    }
}