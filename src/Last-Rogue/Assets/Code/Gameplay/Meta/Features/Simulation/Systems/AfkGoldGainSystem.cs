using Entitas;

namespace Code.Gameplay.Meta.Features.Simulation.Systems
{
    public class AfkGoldGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _tick;
        private readonly IGroup<MetaEntity> _storage;

        public AfkGoldGainSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);
            _storage = meta.GetGroup(MetaMatcher
                .AllOf(MetaMatcher.Storage, 
                    MetaMatcher.Gold,
                    MetaMatcher.GoldPerSecond));
        }

        public void Execute()
        {
            foreach (var tick in _tick)
            {
                foreach (var storage in _storage)
                {
                    storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSecond);
                }
            }
        }
    }
}